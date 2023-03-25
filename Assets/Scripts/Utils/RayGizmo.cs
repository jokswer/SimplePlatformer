using UnityEngine;

namespace Utils
{
    public class RayGizmo : MonoBehaviour
    {
        private void OnDrawGizmosSelected()
        {
            var ray = new Ray(transform.position, transform.forward);
            Gizmos.DrawRay(ray);
        }
    }
}