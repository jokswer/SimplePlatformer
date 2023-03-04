using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20;
    [SerializeField] private float _lfeTime = 4f;
    [SerializeField] private TrailRenderer _trailRenderer;

    private Rigidbody _rigidbody;
    private IObjectPool<Bullet> _pool;

    public void Init(IObjectPool<Bullet> pool)
    {
        _rigidbody = GetComponent<Rigidbody>();
        _pool = pool;
    }

    public void OnGet(Transform spawn)
    {
        transform.position = spawn.position;
        transform.rotation = spawn.rotation;

        if (_rigidbody)
            _rigidbody.velocity = _speed * spawn.forward;

        StartCoroutine(AutoRelease());
    }

    private IEnumerator AutoRelease()
    {
        yield return new WaitForSeconds(_lfeTime);
     
        if(gameObject.activeSelf)
            _pool?.Release(this);
    }
    
    private void OnDisable()
    {
        _trailRenderer.Clear();
    }
    
    private void OnCollisionEnter()
    {
        _pool?.Release(this);
    }
}