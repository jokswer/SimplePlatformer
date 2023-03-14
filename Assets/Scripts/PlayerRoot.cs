using Player;
using Player.Models;
using Player.Views;
using UnityEngine;

public class PlayerRoot : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;

    [Header("Player Config")] 
    [SerializeField] private float _moveForce = 5f;

    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _horizontalFriction = 1;
    [SerializeField] private int _maxHealth = 8;
    [SerializeField] private int _health = 3;

    private PlayerPresenter _playerPresenter;
    private PlayerModel _playerModel;
    private PlayerInput _playerInput;

    public PlayerInput PlayerInput => _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerView.HandleAwake();
        _playerModel = new PlayerModel(_playerInput, _moveForce, _horizontalFriction, _jumpForce, _health, _maxHealth);
        _playerPresenter = new PlayerPresenter(_playerView, _playerModel);
    }

    private void Update()
    {
        _playerPresenter.Update();
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