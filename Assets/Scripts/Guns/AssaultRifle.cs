using Player.Views;
using UnityEngine;
using UnityEngine.Events;

namespace Guns
{
    public class AssaultRifle : Gun
    {
        [SerializeField] private int _numberOfBullets;
        [SerializeField] private PlayerArmoryView _playerArmoryView;

        public UnityEvent<int> OnNumberOfBulletsChange;
        public UnityEvent OnActivate;
        public UnityEvent OnDiactivate;

        public override void Shot()
        {
            base.Shot();
            _numberOfBullets -= 1;
            OnNumberOfBulletsChange.Invoke(_numberOfBullets);

            if (_numberOfBullets == 0)
            {
                Hide();
            }
        }

        public override void Activate()
        {
            base.Activate();
            OnActivate.Invoke();
            OnNumberOfBulletsChange.Invoke(_numberOfBullets);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            OnDiactivate.Invoke();
        }

        private void Hide()
        {
            _playerArmoryView.TakeGun(GunType.Pistol);
        }
    }
}