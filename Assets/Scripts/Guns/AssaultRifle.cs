using Player.Views;
using UnityEngine;
using UnityEngine.Events;

namespace Guns
{
    public class AssaultRifle : Gun, IWithBullets
    {
        [SerializeField] private PlayerArmoryView _playerArmoryView;
        [SerializeField] private int _numberOfBullets = 30;

        public UnityEvent<int> OnNumberOfBulletsChange;
        public UnityEvent OnActivate;
        public UnityEvent OnDiactivate;

        public int NumberOfBullets
        {
            get => _numberOfBullets;
            private set => _numberOfBullets = value;
        }

        public override void Shot()
        {
            base.Shot();
            NumberOfBullets -= 1;
            OnNumberOfBulletsChange.Invoke(NumberOfBullets);

            if (NumberOfBullets == 0)
            {
                Hide();
            }
        }

        public override void Activate()
        {
            base.Activate();
            OnActivate.Invoke();
            OnNumberOfBulletsChange.Invoke(NumberOfBullets);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            OnDiactivate.Invoke();
        }

        public void AddBullets(int value)
        {
            NumberOfBullets += value;
            OnNumberOfBulletsChange.Invoke(NumberOfBullets);
        }

        private void Hide()
        {
            _playerArmoryView.TakeGun(GunType.Pistol);
        }
    }
}