using UnityEngine;
using Utils;

namespace Player.Views
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerHealthView))]
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform _modelTransform;
        [SerializeField] private Transform _bodyModel;
        [SerializeField] private Transform _aim;
        [SerializeField] private float _crouchRate = 15f;
        [SerializeField] private float _rotateRate = 20f;
        [SerializeField] private float _maxRotateAngel = 30f;

        private Rigidbody _rigidbody;
        private PlayerHealthView _playerHealth;
        private PlayerArmoryView _playerArmory;
        private Blink _blink;
        private bool _grounded = true;

        public PlayerHealthView PlayerHealth => _playerHealth;
        public PlayerArmoryView PlayerArmory => _playerArmory;
        public Blink PlayerBlink => _blink;

        public void Init()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playerHealth = GetComponent<PlayerHealthView>();
            _playerArmory = GetComponent<PlayerArmoryView>();
            _blink = GetComponent<Blink>();
        }

        private void OnCollisionStay(Collision collisionInfo)
        {
            if (PlayerUtils.CheckCanJump(collisionInfo.contacts))
            {
                _grounded = true;
            }
        }

        private void OnCollisionExit()
        {
            _grounded = false;
        }

        public void HorizontalMove(float force, float friction)
        {
            var speedMultiplier = PlayerUtils.GetSpeedMultiplier(_rigidbody.velocity.x, force, _grounded);

            _rigidbody.AddForce(force * speedMultiplier * Vector3.right, ForceMode.VelocityChange);

            AddHorizontalDrag(friction);
        }

        public void Jump(float force)
        {
            if (force == 0 || !_grounded) return;

            _rigidbody.AddForce(force * Vector3.up, ForceMode.VelocityChange);
        }

        public void BoostJump(Vector3 position, float force)
        {
            _rigidbody.AddForce(position * force, ForceMode.VelocityChange);
        }

        public void Crouch(bool isCrouch)
        {
            var rate = Time.deltaTime * _crouchRate;
            var yScale = isCrouch || !_grounded ? 0.5f : 1;
            var nextScale = Vector3.Lerp(_modelTransform.localScale, new Vector3(1, yScale, 1), rate);

            _modelTransform.localScale = nextScale;
        }

        public void Rotate()
        {
            var x = transform.position.x - _aim.position.x;
            var angel = x > 0 ? _maxRotateAngel : -_maxRotateAngel;

            _bodyModel.rotation = Quaternion.Lerp(_bodyModel.rotation,
                Quaternion.Euler(0, angel, 0), Time.deltaTime * _rotateRate);
        }

        private void AddHorizontalDrag(float friction)
        {
            if (!_grounded) return;

            _rigidbody.AddForce(-_rigidbody.velocity.x * friction * Vector3.right, ForceMode.VelocityChange);
        }
    }
}