namespace Player.Models
{
    public class PlayerModel
    {
        private PlayerInput _playerInput;
        private PlayerHealthModel _playerHealthModel;
        private float _horizontalFriction;
        private float _moveForce;
        private float _jumpForce;

        public float HorizontalFriction => _horizontalFriction;
        public float HorizontalForce => _playerInput.Move.x * _moveForce;
        public float JumpForce => _playerInput.IsJumped ? _jumpForce : 0;
        public bool IsCrouched => _playerInput.IsCrouched;
        public PlayerHealthModel PlayerHealth => _playerHealthModel;

        public PlayerModel(PlayerInput playerInput, float moveForce, float horizontalFriction, float jumpForce,
            int health, int maxHealth)
        {
            _playerHealthModel = new PlayerHealthModel(maxHealth, health);
            
            _playerInput = playerInput;
            _moveForce = moveForce;
            _horizontalFriction = horizontalFriction;
            _jumpForce = jumpForce;
        }

        public void OnEnable()
        {
            _playerInput.Enable();
        }

        public void OnDisable()
        {
            _playerInput.Disable();
        }
    }
}