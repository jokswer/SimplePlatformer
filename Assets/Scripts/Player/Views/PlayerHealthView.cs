using System;
using System.Collections;
using UnityEngine;

namespace Player.Views
{
    public class PlayerHealthView : MonoBehaviour
    {
        [SerializeField] private float _invulnerableTime = 1f;
        
        public Action<int> OnAddHealth;
        public Func<int, bool> OnTakeDamage;
        public Action OnStopInvulnerable;

        public void AddHealth(int value)
        {
            OnAddHealth?.Invoke(value);
        }

        public void TakeDamage(int value)
        {
            var canTakeDamage = OnTakeDamage?.Invoke(value);

            if (canTakeDamage != null && canTakeDamage.Value)
            {
                StartCoroutine(StopInvulnerable());
            }
        }

        private IEnumerator StopInvulnerable()
        {
            yield return new WaitForSeconds(_invulnerableTime);
            OnStopInvulnerable?.Invoke();
        }
    }
}