using UnityEngine;
using UnityEngine.Pool;

namespace Pool
{
    public abstract class BasePool<T> : MonoBehaviour where T : class
    {
        private IObjectPool<T> _pool;

        public IObjectPool<T> Pool
        {
            get => _pool;
            protected set => _pool = value;
        }

        protected abstract void OnDestroyObject(T obj);
        protected abstract void OnRelease(T obj);
        protected abstract void OnGet(T obj);
        protected abstract T Create();
    }
}