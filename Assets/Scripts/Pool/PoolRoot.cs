using System;
using Enemy;
using UnityEngine;

public enum PoolType
{
    Acorn,
    Carrot,
    Rocket,
}

namespace Pool
{
    public class PoolRoot : MonoBehaviour
    {
        [SerializeField] private BasePool<Carrot> _carrotsPool;
        [SerializeField] private BasePool<Rocket> _rocketsPool;
        [SerializeField] private BasePool<Acorn> _acornsPool;

        private static PoolRoot _instantiate;
        public PoolRoot Instantiate => _instantiate;

        private void Awake()
        {
            if (!_instantiate)
            {
                _instantiate = this;
            }
        }

        public IPoolObject Get(PoolType type)
        {
            return type switch
            {
                PoolType.Acorn => _acornsPool.Pool.Get(),
                PoolType.Carrot => _carrotsPool.Pool.Get(),
                PoolType.Rocket => _rocketsPool.Pool.Get(),
                _ => throw new ArgumentException()
            };
        }
    }
}