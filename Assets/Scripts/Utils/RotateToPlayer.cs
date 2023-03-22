using Player.Views;
using UnityEngine;

namespace Utils
{
    public class RotateToPlayer : MonoBehaviour
    {
        [SerializeField] private Vector3 _rightEuler;
        [SerializeField] private Vector3 _leftEuler;
        [SerializeField] private float _rotationSpeed = 5f;

        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerView>().transform;
        }

        private void Update()
        {
            var targetEuler = transform.position.x < _playerTransform.position.x ? _rightEuler : _leftEuler;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetEuler),
                Time.deltaTime * _rotationSpeed);
        }
    }
}