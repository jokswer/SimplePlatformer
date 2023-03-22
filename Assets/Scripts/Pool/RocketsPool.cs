using Enemy;
using UnityEngine;
using UnityEngine.Pool;

namespace Pool
{
    public class RocketsPool : BasePool<Rocket>
    {
        [SerializeField] private Rocket _rocketPreffab;
        
        private void Awake()
        {
            Pool = new ObjectPool<Rocket>(Create, OnGet, OnRelease, OnDestroyObject);
        }
        
        protected override void OnDestroyObject(Rocket obj)
        {
            Destroy(obj.gameObject);
        }

        protected override void OnRelease(Rocket obj)
        {
            obj.gameObject.SetActive(false);
        }

        protected override void OnGet(Rocket obj)
        {
            obj.gameObject.SetActive(true);
        }

        protected override Rocket Create()
        {
            var rocket = Instantiate(_rocketPreffab, Vector3.zero, Quaternion.identity, transform);
            rocket.Init(Pool);

            return rocket;
        }
    }
}