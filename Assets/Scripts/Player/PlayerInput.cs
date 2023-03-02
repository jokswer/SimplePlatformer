using UnityEngine;

namespace Player
{
    public class PlayerInput
    {
        private InputActions _inputActions;

        public Vector2 Move => _inputActions.Player.Move.ReadValue<Vector2>();
        public bool IsJumped => _inputActions.Player.Jump.WasPressedThisFrame();
        public bool IsCrouched => _inputActions.Player.Crouch.IsInProgress();

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