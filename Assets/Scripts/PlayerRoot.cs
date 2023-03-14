using Player;
using Player.Models;
using Player.Views;
using UI;
using UnityEngine;

public class PlayerRoot : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private HealthUI _healthUI;

    [Header("Player Config")] 
    [SerializeField] private float _moveForce = 5f;

    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _horizontalFriction = 1;
    [SerializeField] private int _maxHealth = 8;
    [SerializeField] private int _health = 4;

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
        
        _healthUI.Setup(_maxHealth, _health);
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
        _playerModel.PlayerHealth.OnHealthChange += _healthUI.Change;
    }

    private void OnDisable()
    {
        _playerPresenter.OnDisable();
        _playerModel.PlayerHealth.OnHealthChange -= _healthUI.Change;
    }
}