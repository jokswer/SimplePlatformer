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
            _playerView.Jump(_playerModel.JumpForce);
        }

        public void FixedUpdate()
        {
            _playerView.HorizontalMove(_playerModel.HorizontalForce, _playerModel.HorizontalFriction);
        }

        public void OnEnable()
        {
            _playerModel.OnEnable();
        }

        public void OnDisable()
        {
            _playerModel.OnDisable();
        }
    }
}