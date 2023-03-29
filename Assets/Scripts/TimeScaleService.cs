using Player;
using UnityEngine;

public class TimeScaleService : MonoBehaviour
{
    [SerializeField] private float _timeScale = 0.3f;
    [SerializeField] private PlayerRoot _playerRoot;

    private float _startFixedDeltaTime;

    private void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }

    private void Update()
    {
        if (_playerRoot.PlayerInput.TimeScaleStart)
        {
            Time.timeScale = _timeScale;
            Time.fixedDeltaTime = _startFixedDeltaTime * _timeScale;
        }
        else if (_playerRoot.PlayerInput.TimeScaleStop)
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = _startFixedDeltaTime;
        }
    }
}