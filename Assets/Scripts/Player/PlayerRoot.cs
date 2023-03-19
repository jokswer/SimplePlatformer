using Player.Models;
using Player.Views;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerRoot : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private HealthUI _healthUI;
        [SerializeField] private DamageScreen _damageScreen;
        [SerializeField] private AudioSource _damageAudio;
        [SerializeField] private AudioSource _pickUpHealthAudio;

        [Header("Player Config")] 
        [SerializeField] private float _moveForce = 5f;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private float _horizontalFriction = 1;
        [SerializeField] private int _maxHealth = 8;
        [SerializeField] private int _health = 4;
        [SerializeField] private float _invulnerableTime = 1f;

        private PlayerPresenter _playerPresenter;
        private PlayerModel _playerModel;
        private PlayerInput _playerInput;

        public PlayerInput PlayerInput => _playerInput;

        private void Awake()
        {
            _playerView.Init();
            _playerInput = new PlayerInput();
            _playerModel = new PlayerModel(
                _playerInput,
                _moveForce, 
                _horizontalFriction, 
                _jumpForce, 
                _health, 
                _maxHealth,
                _invulnerableTime);
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
            _playerModel.PlayerHealth.OnTakeDamage += _damageScreen.StartEffect;
            _playerModel.PlayerHealth.OnTakeDamage += _damageAudio.Play;
            _playerModel.PlayerHealth.OnTakeHealth += _pickUpHealthAudio.Play;
        }

        private void OnDisable()
        {
            _playerPresenter.OnDisable();
            _playerModel.PlayerHealth.OnHealthChange -= _healthUI.Change;
            _playerModel.PlayerHealth.OnTakeDamage -= _damageScreen.StartEffect;
            _playerModel.PlayerHealth.OnTakeDamage -= _damageAudio.Play;
            _playerModel.PlayerHealth.OnTakeHealth -= _pickUpHealthAudio.Play;
        }
    }
}