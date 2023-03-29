using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ChargeUI : MonoBehaviour
    {
        [SerializeField] private Image _foregroound;
        [SerializeField] private Image _background;
        [SerializeField] private TMP_Text _time;

        public void StartCharge()
        {
            _background.color = new Color(1, 1, 1, 0.2f);
            _foregroound.enabled = true;
            _time.enabled = true;
        }

        public void StopCharge()
        {
            _background.color = Color.white;
            _foregroound.enabled = false;
            _time.enabled = false;
        }

        public void SetChargeValue(float current, float max)
        {
            _foregroound.fillAmount = current / max;
            _time.text = Mathf.Ceil(max - current).ToString();
        }
    }
}