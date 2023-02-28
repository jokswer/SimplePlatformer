namespace Player
{
    public class PlayerModel
    {
        private PlayerInput _playerInput;
        private float _horizontalFriction;
        private float _moveForce;

        public float HorizontalFriction => _horizontalFriction;
        public float HorizontalForce => _playerInput.Move.x * _moveForce;
        public float VerticalForce => _playerInput.Move.y * _moveForce;

        public PlayerModel(float moveForce, float horizontalFriction)
        {
            _playerInput = new PlayerInput();
            _moveForce = moveForce;
            _horizontalFriction = horizontalFriction;
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