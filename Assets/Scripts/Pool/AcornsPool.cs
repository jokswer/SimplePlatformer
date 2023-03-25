using Enemy;
using UnityEngine;
using UnityEngine.Pool;

namespace Pool
{
    public class AcornsPool : BasePool<Acorn>
    {
        [SerializeField] private Acorn _acornPrefab;

        private void Awake()
        {
            Pool = new ObjectPool<Acorn>(Create, OnGet, OnRelease, OnDestroyObject);
        }
        protected override void OnDestroyObject(Acorn obj)
        {
            Destroy(obj.gameObject);
        }

        protected override void OnRelease(Acorn obj)
        {
            obj.gameObject.SetActive(false);
        }

        protected override void OnGet(Acorn obj)
        {
            obj.gameObject.SetActive(true);
        }

        protected override Acorn Create()
        {
            var acorn = Instantiate(_acornPrefab, Vector3.zero, Quaternion.identity, transform);
            acorn.Init(Pool);

            return acorn;
        }
    }
}