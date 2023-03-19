using UnityEngine;
using UnityEngine.Pool;

namespace Pool
{
    public class HitsPool : BasePool<Hit>
    {
        [SerializeField] private Hit _hitPrefab;

        private void Awake()
        {
            Pool = new ObjectPool<Hit>(Create, OnGet, OnRelease, OnDestroyObject);
        }

        protected override void OnDestroyObject(Hit hit)
        {
            Destroy(hit.gameObject);
        }

        protected override void OnRelease(Hit hit)
        {
            hit.gameObject.SetActive(false);
        }

        protected override void OnGet(Hit hit)
        {
            hit.gameObject.SetActive(true);
        }

        protected override Hit Create()
        {
            var hit = Instantiate(_hitPrefab, Vector3.zero, Quaternion.identity, transform);
            hit.Init(Pool);

            return hit;
        }
    }
}