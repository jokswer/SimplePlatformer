using Enemy;
using UnityEngine;
using UnityEngine.Pool;

namespace Pool
{
    public class CarrotPool : BasePool<Carrot>
    {
        [SerializeField] private Carrot _carrotPreffab;

        private void Awake()
        {
            Pool = new ObjectPool<Carrot>(Create, OnGet, OnRelease, OnDestroyObject);
        }

        protected override void OnDestroyObject(Carrot carrot)
        {
            Destroy(carrot.gameObject);
        }

        protected override void OnRelease(Carrot carrot)
        {
            carrot.gameObject.SetActive(false);
        }

        protected override void OnGet(Carrot carrot)
        {
            carrot.gameObject.SetActive(true);
        }

        protected override Carrot Create()
        {
            var carrot = Instantiate(_carrotPreffab, Vector3.zero, Quaternion.identity, transform);
            carrot.Init(Pool);

            return carrot;
        }
    }
}