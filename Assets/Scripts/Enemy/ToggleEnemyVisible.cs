using System;
using UnityEditor;
using UnityEngine;

namespace Enemy
{
    public class ToggleEnemyVisible : MonoBehaviour
    {
        [SerializeField] private float _maxDistance = 20f;
        public float MaxDistance => _maxDistance;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            if (gameObject.activeSelf) return;

            gameObject.SetActive(true);
        }

        public void Hide()
        {
            if (!gameObject.activeSelf) return;

            gameObject.SetActive(false);
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Handles.DrawWireDisc(transform.position, Vector3.forward, _maxDistance);
        }
    }
#endif
}