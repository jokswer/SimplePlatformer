using UnityEngine;
using UnityEngine.Pool;

namespace Pool
{
    public class BulletsPool : BasePool<Bullet>
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private HitsPool _hitsPool;

        private void Awake()
        {
            Pool = new ObjectPool<Bullet>(Create, OnGet, OnRelease, OnDestroyObject);
        }

        protected override void OnDestroyObject(Bullet bullet)
        {
            Destroy(bullet.gameObject);
        }

        protected override void OnRelease(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }

        protected override void OnGet(Bullet bullet)
        {
            bullet.OnGet(_spawnPoint);
        }

        protected override Bullet Create()
        {
            var bullet = Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation, transform);
            bullet.Init(Pool, _hitsPool.Pool);

            return bullet;
        }
    }
}