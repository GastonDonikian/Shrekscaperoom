using System;
using GlobalScripts;
using UnityEngine;
using UnityEngine.Audio;
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
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private Image _brightnessOverlay;
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
            _audioMixer.SetFloat("BG_Music", GlobalUpgrades.instance.volume);
            _sliderVolume.value = GlobalUpgrades.instance.volume;
            
            _brightnessOverlay.color = GlobalUpgrades.instance.brightness;
            _sliderBrightness.value = GlobalUpgrades.instance.brightness.a;
        }

        public void AdjustMusicVolume()
        {
            _audioMixer.SetFloat("BG_Music", _sliderVolume.value);
            GlobalUpgrades.instance.volume = _sliderVolume.value;
        }

        public void AdjustBrightness()
        {
            Color tempColor = _brightnessOverlay.color;
            tempColor.a = _sliderBrightness.value;
            GlobalUpgrades.instance.brightness = tempColor;
            _brightnessOverlay.color = tempColor;
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
