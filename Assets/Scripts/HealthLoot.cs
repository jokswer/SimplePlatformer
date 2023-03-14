using Player.Views;
using UnityEngine;

public class HealthLoot : MonoBehaviour
{
    [SerializeField] private int _healthValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent<PlayerView>(out var playerView))
        {
            playerView.PlayerHealth.AddHealth(_healthValue);
            Destroy(gameObject);
        }
    }
}