using System;
using System.Collections.Generic;
using Guns;
using UnityEngine;

namespace Player.Views
{
    public class PlayerArmoryView : MonoBehaviour
    {
        [SerializeField] private GunType _currentGun;
        [SerializeField] private Gun[] _guns;

        private Dictionary<GunType, Gun> _gunsDictionary = new Dictionary<GunType, Gun>();

        private void Awake()
        {
            ConfigDictionary();
            TakeGun(_currentGun);
        }

        private void ConfigDictionary()
        {
            foreach (var gun in _guns)
            {
                switch (gun)
                {
                    case Pistol:
                        _gunsDictionary.Add(GunType.Pistol, gun);
                        break;
                    case AssaultRifle:
                        _gunsDictionary.Add(GunType.AssaultRifle, gun);
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
        }

        public void TakeGun(GunType type)
        {
            _currentGun = type;

            foreach (var key in _gunsDictionary.Keys)
            {
                if (key == type)
                {
                    _gunsDictionary[key].Activate();
                }
                else
                {
                    _gunsDictionary[key].Deactivate();
                }
            }
        }

        public void AddBullets(GunType type, int value)
        {
            if (_gunsDictionary[type] is IWithBullets gunWithBullets)
            {
                gunWithBullets.AddBullets(value);
                TakeGun(type);
            }
        }
    }
}