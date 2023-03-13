using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private PlayerRoot _playerRoot;
    [SerializeField] private BulletsPool _bulletsPool;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private GameObject _flash;

    [SerializeField] private float _shotPeriod = 0.2f;
    [SerializeField] private float _flashLifetime = 0.08f;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (!(_timer > _shotPeriod)) return;

        if (_playerRoot.PlayerInput.IsShooting)
        {
            _timer = 0;
            
            _bulletsPool.Pool.Get();
            _shotSound.Play();
            _flash.SetActive(true);
            StartCoroutine(HideFlash());
        }
    }

    private IEnumerator HideFlash()
    {
        yield return new WaitForSeconds(_flashLifetime);
        _flash.SetActive(false);
    }
}