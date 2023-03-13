using UnityEngine;

namespace EnemyBase
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int _health;

        public void TakeDamage(int damage = 1)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}