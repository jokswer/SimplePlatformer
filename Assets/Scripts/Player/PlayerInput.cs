using UnityEngine;

namespace Player
{
    public class PlayerInput
    {
        private InputActions _inputActions;

        public Vector2 Move => _inputActions.Player.Move.ReadValue<Vector2>();
        public bool IsJumped => _inputActions.Player.Jump.WasPressedThisFrame();
        public bool IsCrouched => _inputActions.Player.Crouch.IsInProgress();
        public Vector2 MousePosition => _inputActions.Player.MousePosition.ReadValue<Vector2>();
        public bool IsShooting => _inputActions.Player.Shot.IsInProgress();
        public bool JumpGunIsUse => _inputActions.Player.JumpGun.WasPressedThisFrame();

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