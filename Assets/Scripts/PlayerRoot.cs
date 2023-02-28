using Player;
using UnityEngine;

public class PlayerRoot : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    
    [Header("Player Config")]
    [SerializeField] private float _moveForce = 5f;
    // [SerializeField] private float _speedForce = 10f;
    [SerializeField] private float _horizontalFriction = 1;

    private PlayerPresenter _playerPresenter;
    private PlayerModel _playerModel;

    private void Awake()
    {
        _playerModel = new PlayerModel(_moveForce, _horizontalFriction);
        _playerPresenter = new PlayerPresenter(_playerView, _playerModel);
    }

    private void FixedUpdate()
    {
        _playerPresenter.FixedUpdate();
    }

    private void OnEnable()
    {
        _playerPresenter.OnEnable();
    }

    private void OnDisable()
    {
        _playerPresenter.OnDisable();
    }
}