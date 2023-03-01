using UnityEngine;
using Utils;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerView : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private bool _grounded;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionStay(Collision collisionInfo)
        {
            if (PlayerUtils.CheckCanJump(collisionInfo.contacts))
            {
                _grounded = true;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            _grounded = false;
        }

        public void HorizontalMove(float force, float friction)
        {
            var speedMultiplier = PlayerUtils.GetSpeedMultiplier(_rigidbody.velocity.x, force, _grounded);

            _rigidbody.AddForce(force * speedMultiplier * Vector3.right, ForceMode.VelocityChange);

            AddHorizontalDrag(friction);
        }

        public void Jump(float force)
        {
            if (force == 0 || !_grounded) return;

            _rigidbody.AddForce(force * Vector3.up, ForceMode.VelocityChange);
        }

        private void AddHorizontalDrag(float friction)
        {
            if (!_grounded) return;

            _rigidbody.AddForce(-_rigidbody.velocity.x * friction * Vector3.right, ForceMode.VelocityChange);
        }
    }
}