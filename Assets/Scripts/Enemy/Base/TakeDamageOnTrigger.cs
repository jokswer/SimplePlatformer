using UnityEngine;

namespace Enemy.Base
{
    [RequireComponent(typeof(EnemyHealth))]
    public class TakeDamageOnTrigger : MonoBehaviour
    {
        private EnemyHealth _health;
        [SerializeField] private bool _dieOnAnyCollision;

        private void Awake()
        {
            _health = GetComponent<EnemyHealth>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_dieOnAnyCollision && !other.isTrigger)
            {
                _health.TakeMaxDamage();
            }
            
            var rb = other.attachedRigidbody;
            if (rb != null && rb.TryGetComponent<Bullet>(out var bullet))
            {
                _health.TakeDamage();
                bullet.Hit();
            }
        }
    }
}