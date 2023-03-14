using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private GameObject _healthImagePrefab;
        private List<GameObject> _healthImages = new List<GameObject>();

        public void Setup(int maxHealth, int currentHealth)
        {
            for (var i = 0; i < maxHealth; i++)
            {
                var image = Instantiate(_healthImagePrefab, transform);

                var isActive = i < currentHealth;
                image.gameObject.SetActive(isActive);

                _healthImages.Add(image);
            }
        }

        public void Change(int currentHealth)
        {
            for (var i = 0; i < _healthImages.Count; i++)
            {
                var isActive = i < currentHealth;
                _healthImages[i].gameObject.SetActive(isActive);
            }
        }
    }
}