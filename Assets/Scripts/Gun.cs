using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private PlayerRoot _playerRoot;
    [SerializeField] private BulletsPool _bulletsPool;
    
    [SerializeField] private float _shotPeriod = 0.2f;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (!(_timer > _shotPeriod)) return;
        
        if (_playerRoot.PlayerInput.IsShooting)
        {
            _timer = 0;
            _bulletsPool.Pool.Get();
        }
    }
}