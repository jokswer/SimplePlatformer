using UnityEngine;

namespace Enemy
{
    public class ToggleEnemyVisible : MonoBehaviour
    {
        private void Awake()
        {
            gameObject.SetActive(false);

        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}