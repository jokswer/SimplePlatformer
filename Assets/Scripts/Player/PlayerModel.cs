namespace Player
{
    public class PlayerModel
    {
        private PlayerInput _playerInput;
        private float _horizontalFriction;
        private float _moveForce;
        private float _jumpForce;

        public float HorizontalFriction => _horizontalFriction;
        public float HorizontalForce => _playerInput.Move.x * _moveForce;
        public float JumpForce => _playerInput.IsJumped ? _jumpForce : 0;

        public PlayerModel(float moveForce, float horizontalFriction, float jumpForce)
        {
            _playerInput = new PlayerInput();
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