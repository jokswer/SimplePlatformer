using Enemy.Base;
using Player.Views;
using Pool;
using UnityEngine;
using UnityEngine.Pool;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody), typeof(EnemyHealth))]
    public class Carrot : MonoBehaviour, IPoolObject
    {
        [SerializeField] private float _speed = 1;

        private Rigidbody _rigidbody;
        private Transform _target;
        private IObjectPool<Carrot> _pool;
        private EnemyHealth _enemyHealth;

        public void Init(IObjectPool<Carrot> pool)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _enemyHealth = GetComponent<EnemyHealth>();
            _target = FindObjectOfType<PlayerView>().transform;
            _pool = pool;
        }

        public void OnGet(Transform spawn)
        {
            ClearPosition(spawn);
            Move();
        }

        public void Release()
        {
            if (gameObject.activeSelf)
            {
                _enemyHealth.ResetHealth();
                _pool.Release(this);
            }
        }

        private void Move()
        {
            var toTarget = (_target.position - transform.position).normalized;
            _rigidbody.velocity = toTarget * _speed;
        }

        private void ClearPosition(Transform spawn)
        {
            transform.position = spawn.position;
            _rigidbody.MovePosition(spawn.position);
            transform.rotation = Quaternion.identity;
            _rigidbody.MoveRotation(Quaternion.identity);
        }
    }
}