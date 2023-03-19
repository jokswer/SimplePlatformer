using UnityEngine;

namespace Utils
{
    public class CameraTransform : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _lerpRate;

        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _lerpRate);
        }
    }
}