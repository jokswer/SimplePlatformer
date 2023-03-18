using Player.Views;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HenMove : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _timeToReachSpeed = 1f;
    
    private Rigidbody _rigidbody;
    private Transform _target;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _target = FindObjectOfType<PlayerView>().transform;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var toTarget = (_target.position - transform.position).normalized;
        var force = _rigidbody.mass * (toTarget * _speed - _rigidbody.velocity) / _timeToReachSpeed;
        
        _rigidbody.AddForce(force);
    }
}