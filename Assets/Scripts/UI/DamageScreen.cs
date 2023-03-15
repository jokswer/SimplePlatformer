using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DamageScreen : MonoBehaviour
    {
        [SerializeField] private float _effectTime = 1f;
        [SerializeField] private Image _damageImage;

        public void StartEffect() => StartCoroutine(ShowEffect());

        private IEnumerator ShowEffect()
        {
            _damageImage.enabled = true;

            for (var t = _effectTime; t > 0; t -= Time.deltaTime)
            {
                _damageImage.color = new Color(_damageImage.color.r, _damageImage.color.g, _damageImage.color.b, t);
                yield return null;
            }

            _damageImage.enabled = false;
        }
    }
}