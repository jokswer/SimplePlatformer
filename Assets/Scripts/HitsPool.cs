using UnityEngine;
using UnityEngine.Pool;

public class HitsPool : MonoBehaviour
{
    [SerializeField] private Hit _hitPrefab;

    private ObjectPool<Hit> _pool;

    public IObjectPool<Hit> Pool => _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Hit>(CreateHit, OnGetHit, OnReleaseHit, OnDestroyHit);
    }

    private void OnDestroyHit(Hit hit)
    {
        Destroy(hit.gameObject);
    }

    private void OnReleaseHit(Hit hit)
    {
        hit.gameObject.SetActive(false);
    }

    private void OnGetHit(Hit hit)
    {
        hit.gameObject.SetActive(true);
    }

    private Hit CreateHit()
    {
        var hit = Instantiate(_hitPrefab, Vector3.zero, Quaternion.identity, transform);
        hit.Init(_pool);

        return hit;
    }
}