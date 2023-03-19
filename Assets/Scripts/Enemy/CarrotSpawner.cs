using UnityEngine;

namespace Enemy
{
    public class CarrotSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private GameObject _carrotPrefab;

        public void Crate()
        {
            Instantiate(_carrotPrefab, _spawnPosition.position, Quaternion.identity);
        }
    }
}