using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20;
    [SerializeField] private float _lifeTime = 3f;

    private Rigidbody _rigidbody;
    private IObjectPool<Bullet> _bulletsPool;
    private IObjectPool<Hit> _hitsPool;

    public void Init(IObjectPool<Bullet> bulletsPool, IObjectPool<Hit> hitsPool)
    {
        _rigidbody = GetComponent<Rigidbody>();
        _bulletsPool = bulletsPool;
        _hitsPool = hitsPool;
    }

    public void OnGet(Transform spawn)
    {
        _rigidbody.MovePosition(spawn.position);
        _rigidbody.MoveRotation(spawn.rotation);
        
        if (_rigidbody)
            _rigidbody.velocity = _speed * spawn.forward;

        StartCoroutine(AutoRelease());
    }

    private void UseEffect()
    {
        var hit = _hitsPool.Get();
        hit.OnGet(transform.position);
    }

    private IEnumerator AutoRelease()
    {
        yield return new WaitForSeconds(_lifeTime);
     
        if(gameObject.activeSelf)
            _bulletsPool?.Release(this);
    }

    private void OnCollisionEnter()
    {
        _bulletsPool?.Release(this);
        UseEffect();
    }
}