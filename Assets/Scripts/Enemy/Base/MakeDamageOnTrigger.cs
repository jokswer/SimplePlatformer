using Player.Views;
using UnityEngine;

namespace Enemy.Base
{
    public class MakeDamageOnTrigger : MonoBehaviour
    {
        [SerializeField] private int _damageValue = 1;

        private void OnTriggerEnter(Collider other)
        {
            var rb = other.attachedRigidbody;
            if (rb != null && rb.TryGetComponent<PlayerView>(out var player))
            {
                player.PlayerHealth.TakeDamage(_damageValue);
            }
        }
    }
}