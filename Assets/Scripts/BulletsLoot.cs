using Guns;
using Player.Views;
using UnityEngine;

public class BulletsLoot : MonoBehaviour
{
    [SerializeField] private GunType _type;
    [SerializeField] private int _numberOfBullets = 30;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent<PlayerView>(out var playerView))
        {
            playerView.PlayerArmory.AddBullets(_type, _numberOfBullets);
            Destroy(gameObject);
        }
    }
}