using System.Collections;
using Player;
using Player.Views;
using UI;
using UnityEngine;

namespace Guns
{
    public class JumpGun : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private PlayerRoot _playerRoot;
        [SerializeField] private Transform _spawn;
        [SerializeField] private Gun _pistol;
        [SerializeField] private ChargeUI _chargeUI;

        [SerializeField] private float _force = 10f;
        [SerializeField] private float _cooldown = 3f;

        private bool _isCharged = true;
        private float _cooldownTime;

        private void Update()
        {
            if (_playerRoot.PlayerInput.JumpGunIsUse && _isCharged)
            {
                _playerView.BoostJump(-_spawn.forward, _force);
                _pistol.Shot();
                _isCharged = false;
                _chargeUI.StartCharge();

                StartCoroutine(StartCooldown());
            }
        }

        private IEnumerator StartCooldown()
        {
            while (_cooldownTime < _cooldown)
            {
                _cooldownTime += Time.unscaledDeltaTime;
                _chargeUI.SetChargeValue(_cooldownTime, _cooldown);
                yield return null;
            }

            _isCharged = true;
            _cooldownTime = 0;
            _chargeUI.StopCharge();

            yield return null;
        }
    }
}