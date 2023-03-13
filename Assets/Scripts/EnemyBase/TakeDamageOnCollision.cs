using UnityEngine;

namespace EnemyBase
{
    [RequireComponent(typeof(EnemyHealth))]
    public class TakeDamageOnCollision : MonoBehaviour
    {
        private EnemyHealth _health;

        private void Awake()
        {
            _health = GetComponent<EnemyHealth>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            var rb = collision.rigidbody;
            
            if (rb != null && rb.TryGetComponent<Bullet>(out var bullet))
            {
                _health.TakeDamage();
            }
        }
    }
}