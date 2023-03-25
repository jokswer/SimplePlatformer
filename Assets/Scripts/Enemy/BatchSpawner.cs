using UnityEngine;

namespace Enemy
{
    public class BatchSpawner : MonoBehaviour
    {
        [SerializeField] private Spawner[] _spawners;

        public void Create()
        {
            foreach (var spawner in _spawners)
            {
                spawner.Create();
            }
        }
    }
}