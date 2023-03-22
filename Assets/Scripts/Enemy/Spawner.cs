using Pool;
using UnityEngine;

namespace Enemy
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private PoolType _type;
        
        private PoolRoot _poolRoot;

        private void Awake()
        {
            _poolRoot = FindObjectOfType<PoolRoot>();
        }

        public void Create()
        {
            var obj = _poolRoot.Instantiate.Get(_type);
            obj.OnGet(_spawnPosition);
        }
    }
}