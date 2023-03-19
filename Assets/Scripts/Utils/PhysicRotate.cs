using UnityEngine;

namespace Utils
{
    [RequireComponent(typeof(Rigidbody))]
    public class PhysicRotate : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotateSpeed;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            var deltaRotation = Quaternion.Euler(_rotateSpeed);
            _rigidbody.MoveRotation(deltaRotation * _rigidbody.rotation);
        }
    }
}
