using UnityEngine;

namespace Player
{
    public class PlayerInput
    {
        private InputActions _inputActions;

        public Vector2 Move => _inputActions.Player.Move.ReadValue<Vector2>();

        public PlayerInput()
        {
            _inputActions = new InputActions();
        }

        public void Enable()
        {
            _inputActions.Player.Enable();
        }

        public void Disable()
        {
            _inputActions.Player.Disable();
        }
    }
}