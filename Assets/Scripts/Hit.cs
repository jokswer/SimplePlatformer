using System.Collections;
using Pool;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(ParticleSystem))]
public class Hit : MonoBehaviour, IPoolObject
{
    private IObjectPool<Hit> _pool;
    private ParticleSystem _particleSystem;
    private float _lifeTime = 1f;
        
    public void Init(IObjectPool<Hit> pool)
    {
        _pool = pool;
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void OnGet(Transform spawn)
    {
        transform.position = spawn.position;
        _particleSystem.Play();
        
        StartCoroutine(AutoRelease());
    }
    
    private IEnumerator AutoRelease()
    {
        yield return new WaitForSeconds(_lifeTime);
        _pool.Release(this);
    }
}