using UnityEngine;
using UnityEngine.Pool;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private HitsPool _hitsPool;

    private ObjectPool<Bullet> _pool;

    public IObjectPool<Bullet> Pool => _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Bullet>(CreateBullet, OnGetBullet, OnReleaseBullet, OnDestroyBullet);
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    private void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.OnGet(_spawnPoint);
    }

    private Bullet CreateBullet()
    {
        var bullet = Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation, transform);
        bullet.Init(_pool, _hitsPool.Pool);

        return bullet;
    }
}