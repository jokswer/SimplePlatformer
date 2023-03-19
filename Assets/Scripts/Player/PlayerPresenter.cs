using Player.Models;
using Player.Views;
using UnityEngine;

namespace Player
{
    public class PlayerPresenter
    {
        private PlayerView _playerView;
        private PlayerModel _playerModel;

        public PlayerPresenter(PlayerView playerView, PlayerModel playerModel)
        {
            _playerView = playerView;
            _playerModel = playerModel;
        }

        public void Update()
        {
            _playerView.Rotate();
            _playerView.Jump(_playerModel.JumpForce);
            _playerView.Crouch(_playerModel.IsCrouched);
        }

        public void FixedUpdate()
        {
            _playerView.HorizontalMove(_playerModel.HorizontalForce, _playerModel.HorizontalFriction);
        }

        public void OnEnable()
        {
            _playerModel.OnEnable();
            _playerView.PlayerHealth.OnAddHealth += _playerModel.PlayerHealth.AddHealth;
            _playerView.PlayerHealth.OnTakeDamage += _playerModel.PlayerHealth.TakeDamage;
            _playerModel.PlayerHealth.OnTakeDamage += _playerView.PlayerBlink.StartBlink;
        }

        public void OnDisable()
        {
            _playerModel.OnDisable();
            _playerView.PlayerHealth.OnAddHealth -= _playerModel.PlayerHealth.AddHealth;
            _playerView.PlayerHealth.OnTakeDamage -= _playerModel.PlayerHealth.TakeDamage;
            _playerModel.PlayerHealth.OnTakeDamage -= _playerView.PlayerBlink.StartBlink;
        }
    }
}