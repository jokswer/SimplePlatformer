using TMPro;
using UnityEngine;

namespace UI
{
    public class BulletsUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void SetNumberOfBulletsText(int value)
        {
            _text.SetText(value.ToString());
        }

        public void ShowText()
        {
            _text.enabled = true;
        }

        public void HideText()
        {
            _text.enabled = false;
        }
    }
}