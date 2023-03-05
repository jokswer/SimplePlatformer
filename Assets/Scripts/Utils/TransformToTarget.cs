using UnityEngine;

namespace Utils
{
    public class TransformToTarget : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private void Update()
        {
            transform.position = _target.position;
        }
    }
}