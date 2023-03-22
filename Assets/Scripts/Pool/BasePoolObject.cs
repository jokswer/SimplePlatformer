using UnityEngine;

namespace Pool
{
    public interface IPoolObject
    {
        public void OnGet(Transform transform);
    }
}