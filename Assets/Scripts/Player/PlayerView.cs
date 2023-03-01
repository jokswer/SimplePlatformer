using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerView : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void HorizontalMove(float force, float friction)
        {
            _rigidbody.AddForce(force * Vector3.right, ForceMode.VelocityChange);
            
            AddHorizontalDrag(friction);
        }

        public void Jump(float force)
        {
            _rigidbody.AddForce(force * Vector3.up, ForceMode.VelocityChange);
        }

        private void AddHorizontalDrag(float friction)
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x * friction * Vector3.right, ForceMode.VelocityChange);
        }
    }
}