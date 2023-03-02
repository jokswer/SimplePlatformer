using UnityEngine;

public class PointerService : MonoBehaviour
{
    [SerializeField] private PlayerRoot _playerRoot;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _aim;
    [SerializeField] private Transform _gun;

    private Plane _plane;

    private void Awake()
    {
        _plane = new Plane(Vector3.back, Vector3.zero);
    }

    private void Update()
    {
        TransformAim();
        RotateGun();
    }

    private void TransformAim()
    {
        var ray = _camera.ScreenPointToRay(_playerRoot.PlayerInput.MousePosition);

        _plane.Raycast(ray, out var distance);
        var point = ray.GetPoint(distance);

        _aim.position = point;
    }

    private void RotateGun()
    {
        var toAim = _aim.position - _gun.position;
        _gun.transform.rotation = Quaternion.LookRotation(toAim);
    }
}