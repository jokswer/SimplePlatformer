using UnityEngine;
using UnityEngine.Events;

namespace EnemyBase
{
    public class EnemyHealth : MonoBehaviour
    {
        public UnityEvent OnTakeDamage;
        
        [SerializeField] private int _health;

        public void TakeDamage(int damage = 1)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Die();
            }
            
            OnTakeDamage.Invoke();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}