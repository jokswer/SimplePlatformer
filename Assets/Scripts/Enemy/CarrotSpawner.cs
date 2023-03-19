using Pool;
using UnityEngine;

namespace Enemy
{
    public class CarrotSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private CarrotPool _carrotPool;

        public void Create()
        {
            var carrot = _carrotPool.Pool.Get();
            carrot.OnGet(_spawnPosition);
        }
    }
}