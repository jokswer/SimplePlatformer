using System;
using UnityEngine;

namespace Player.Models
{
    public class PlayerHealthModel
    {
        private int _maxHealth;
        private int _health;

        public bool IsInvulnerable { get; private set; }
        public Action OnDie;

        public PlayerHealthModel(int maxHealth, int health)
        {
            _maxHealth = maxHealth;
            _health = health;
        }

        public bool TakeDamage(int damage = 1)
        {
            if (IsInvulnerable) return false;

            _health -= damage;

            if (_health <= 0)
            {
                _health = 0;
                OnDie?.Invoke();
            }

            IsInvulnerable = true;

            Debug.Log(_health);
            return true;
        }

        public void AddHealth(int health)
        {
            _health += health;

            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }

            Debug.Log(_health);
        }

        public void StopInvulnerable()
        {
            IsInvulnerable = false;
        }
    }
}