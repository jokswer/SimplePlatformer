using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20;
    [SerializeField] private float _lfeTime = 3f;

    private Rigidbody _rigidbody;
    private IObjectPool<Bullet> _pool;

    public void Init(IObjectPool<Bullet> pool)
    {
        _rigidbody = GetComponent<Rigidbody>();
        _pool = pool;
    }

    public void OnGet(Transform spawn)
    {
        _rigidbody.MovePosition(spawn.position);
        _rigidbody.MoveRotation(spawn.rotation);
        
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

    private void OnCollisionEnter()
    {
        _pool?.Release(this);
    }
}