using Player.Views;
using Pool;
using UnityEngine;
using UnityEngine.Pool;

namespace Enemy
{
    public class Rocket : MonoBehaviour, IPoolObject
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _rotationSpeed = 3f;

        private Transform _playerTransform;
        private IObjectPool<Rocket> _pool;

        public void Init(IObjectPool<Rocket> pool)
        {
            _playerTransform = FindObjectOfType<PlayerView>().transform;
            _pool = pool;
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            transform.position += _speed * Time.deltaTime * transform.forward;
        }

        private void Rotate()
        {
            var toPlayer = _playerTransform.position - transform.position;
            var targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }

        public void OnGet(Transform spawn)
        {
            transform.position = spawn.position;
            transform.rotation = spawn.rotation;
        }
        
        public void Release()
        {
            if (gameObject.activeSelf)
            {
                _pool.Release(this);
            }
        }
    }
}