using UnityEngine;
using UnityEngine.Events;

namespace Enemy.Base
{
    public class EnemyHealth : MonoBehaviour
    {
        public UnityEvent OnTakeDamage;
        public UnityEvent OnDie;

        [SerializeField] private bool _destroy = true;
        [SerializeField] private int _health = 1;
        private int _maxHealth;

        private void Start()
        {
            _health = _maxHealth;
        }

        public void TakeDamage(int damage = 1)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Die();
            }

            OnTakeDamage.Invoke();
        }

        public void TakeMaxDamage()
        {
            TakeDamage(_health);
        }

        public void ResetHealth()
        {
            _health = _maxHealth;
        }

        private void Die()
        {
            OnDie.Invoke();
            
            if (_destroy)
            {
                Destroy(gameObject);
            }
        }
    }
}