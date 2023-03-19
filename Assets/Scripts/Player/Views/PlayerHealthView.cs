using System;
using UnityEngine;

namespace Player.Views
{
    public class PlayerHealthView : MonoBehaviour
    {
        public Action<int> OnAddHealth;
        public Action<int> OnTakeDamage;

        public void AddHealth(int value)
        {
            OnAddHealth?.Invoke(value);
        }

        public void TakeDamage(int value)
        {
            OnTakeDamage?.Invoke(value);
        }
    }
}