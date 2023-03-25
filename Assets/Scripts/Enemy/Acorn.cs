using System;
using Enemy.Base;
using Pool;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody), typeof(EnemyHealth))]
    public class Acorn : MonoBehaviour, IPoolObject
    {
        [SerializeField] private Vector3 _force;
        [SerializeField] private float _maxAngelSpeed;
        
        private Rigidbody _rigidbody;
        private IObjectPool<Acorn> _pool;
        private EnemyHealth _enemyHealth;

        public void Init(IObjectPool<Acorn> pool)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _enemyHealth = GetComponent<EnemyHealth>();
            _pool = pool;
        }

        private void OnDisable()
        {
            transform.rotation = Quaternion.identity;
            _rigidbody.MoveRotation(Quaternion.identity);
        }

        public void OnGet(Transform spawn)
        {
            ClearPosition(spawn);

            _rigidbody.AddRelativeForce(_force, ForceMode.VelocityChange);
            _rigidbody.angularVelocity = new Vector3(Random.Range(-_maxAngelSpeed, _maxAngelSpeed),
                Random.Range(-_maxAngelSpeed, _maxAngelSpeed), Random.Range(-_maxAngelSpeed, _maxAngelSpeed));
        }
        
        public void Release()
        {
            if (gameObject.activeSelf)
            {
                _enemyHealth.ResetHealth();
                _pool.Release(this);
            }
        }
        
        private void ClearPosition(Transform spawn)
        {
            transform.position = spawn.position;
            _rigidbody.MovePosition(spawn.position);
            transform.rotation = spawn.rotation;
            _rigidbody.MoveRotation(spawn.rotation);
        }
    }
}