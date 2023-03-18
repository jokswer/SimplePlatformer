using UnityEngine;

namespace Utils
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotateSpeed;

        private void Update()
        {
            transform.Rotate(_rotateSpeed * Time.deltaTime);
        }
    }
}