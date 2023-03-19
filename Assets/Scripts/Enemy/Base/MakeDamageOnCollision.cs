using Player.Views;
using UnityEngine;

namespace Enemy.Base
{
    public class MakeDamageOnCollision : MonoBehaviour
    {
        [SerializeField] private int _damageValue = 1;
        
        private void OnCollisionEnter(Collision collision)
        {
            var rb = collision.rigidbody;
            
            if (rb != null && rb.TryGetComponent<PlayerView>(out var player))
            {
                player.PlayerHealth.TakeDamage(_damageValue);
            }
        }
    }
}