using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Cursor = UnityEngine.Cursor;

namespace Managers
{
    public class SettingsManager : MonoBehaviour
    {

        [SerializeField] private GameObject _menuBackground;
        [SerializeField] private Slider _sliderBrightness;
        [SerializeField] private Slider _sliderVolume;
        [SerializeField] private Button _btnCancel;
        [SerializeField] private bool _isActive;
        private bool _gamePaused;
        
        private void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                EscapeKeyPressed();
            }
        }

        private void Start()
        {
            CloseMenu();
        }

        public void OnCancelClick()
        {
            _gamePaused = false;
            _isActive = false;
            PlayPauseGame();
        }

        public void PlayPauseGame()
        {
            if (_isActive)
            {
                Time.timeScale = 0;
                OpenMenu();
                _gamePaused = true;
            }
            else
            {
                Time.timeScale = 1;
                CloseMenu();
            }
        }

        private void OpenMenu()
        {
            _isActive = true;
            _menuBackground.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }

        private void CloseMenu()
        {
            _isActive = false;
            _menuBackground.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void EscapeKeyPressed()
        {
            _isActive = !_isActive;
            _gamePaused = !_gamePaused;
            PlayPauseGame();

        }
    }
}
