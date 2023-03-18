using Player.Views;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarrotMove : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    
    private Rigidbody _rigidbody;
    private Transform _target;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _target = FindObjectOfType<PlayerView>().transform;
        
        Move();
    }

    private void Move()
    {
        var toTarget = (_target.position - transform.position).normalized;
        _rigidbody.velocity = toTarget * _speed;
    }
}
