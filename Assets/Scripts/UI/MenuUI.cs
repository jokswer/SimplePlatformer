using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private GameObject _menuButton;
        [SerializeField] private GameObject _menuWindow;
        [SerializeField] private TimeScaleService _timeScaleService;
        [SerializeField] private MonoBehaviour[] _componentsToDisable;

        public void OpenMenuWindow()
        {
            _menuButton.SetActive(false);
            _menuWindow.SetActive(true);
            _timeScaleService.SetPauseTimeScale();

            foreach (var component in _componentsToDisable)
            {
                component.enabled = false;
            }
        }

        public void CloseMenuWindow()
        {
            _menuButton.SetActive(true);
            _menuWindow.SetActive(false);
            _timeScaleService.SetGameTimeScale();
            
            foreach (var component in _componentsToDisable)
            {
                component.enabled = true;
            }
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnDestroy()
        {
            _timeScaleService.SetGameTimeScale();
        }
    }
}