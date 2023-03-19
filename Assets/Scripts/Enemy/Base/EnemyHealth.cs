using UnityEngine;
using UnityEngine.Events;

namespace Enemy.Base
{
    public class EnemyHealth : MonoBehaviour
    {
        public UnityEvent OnTakeDamage;
        public UnityEvent OnDie;

        [SerializeField] private int _health = 1;

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

        private void Die()
        {
            //TODO: fix this
            // if (OnDie.GetPersistentEventCount() != 0)
            // {
            //     OnDie.Invoke();
            // }
            // else
            // {
            //     Destroy(gameObject);
            // }
            
            Destroy(gameObject);
        }
    }
}