using UnityEngine;

namespace Utils
{
    public class ClearTrail : MonoBehaviour
    {
        private TrailRenderer _trailRenderer;

        private void Awake()
        {
            _trailRenderer = GetComponent<TrailRenderer>();
        }

        private void OnEnable()
        {
            _trailRenderer.Clear();
        }
    }
}