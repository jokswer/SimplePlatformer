using UnityEngine;

namespace Enemy.Base
{
    [RequireComponent(typeof(EnemyHealth))]
    public class TakeDamageOnTrigger : MonoBehaviour
    {
        private EnemyHealth _health;

        private void Awake()
        {
            _health = GetComponent<EnemyHealth>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var rb = other.attachedRigidbody;
            if (rb != null && rb.TryGetComponent<Bullet>(out var bullet))
            {
                _health.TakeDamage();
            }
        }
    }
}