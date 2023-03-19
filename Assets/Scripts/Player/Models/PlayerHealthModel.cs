using System;
using UnityEngine;

namespace Player.Models
{
    public class PlayerHealthModel
    {
        private float _invulnerableTime;
        private int _maxHealth;
        private int _health;
        private float _lastDamageTime = 0f;

        public Action OnDie;
        public Action<int> OnHealthChange;
        public Action OnTakeDamage;
        public Action OnTakeHealth;

        public PlayerHealthModel(int maxHealth, int health, float invulnerableTime)
        {
            _maxHealth = maxHealth;
            _health = health;
            _invulnerableTime = invulnerableTime;
        }

        public void TakeDamage(int damage = 1)
        {
            var difference = Time.time - _lastDamageTime;

            if (difference > _invulnerableTime)
            {
                _lastDamageTime = Time.time;
                RemoveHealth(damage);
            }
        }

        public void AddHealth(int health)
        {
            _health += health;

            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
            
            OnHealthChange?.Invoke(_health);
            OnTakeHealth?.Invoke();
        }

        private void RemoveHealth(int value)
        {
            _health -= value;

            if (_health <= 0)
            {
                _health = 0;
                OnDie?.Invoke();
            }
            
            OnHealthChange?.Invoke(_health);
            OnTakeDamage?.Invoke();
        }
        
    }
}