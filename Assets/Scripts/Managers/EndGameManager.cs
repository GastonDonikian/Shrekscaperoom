using System;
using GlobalScripts;
using Sounds;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class EndGameManager : MonoBehaviour
    {
        [SerializeField] private Sprite _victory;
        [SerializeField] private Sprite _defeat;
        [SerializeField] private Image _background;

        [SerializeField] private AudioClip _victorySound;
        [SerializeField] private AudioClip _defeatSound;
        private BackgroundMusicController _backgroundMusicController;
        
        [SerializeField] private Sprite _victoryText;
        [SerializeField] private Sprite _defeatText;
        [SerializeField] private Image _imageText;
        private void Start()
        {
            bool tester = GlobalVictory.instance.IsVictory;
            //bool tester = true;
            _backgroundMusicController = GetComponent<BackgroundMusicController>();
            _background.sprite = tester ? _victory : _defeat;
            _imageText.sprite = tester ? _victoryText : _defeatText;
            _backgroundMusicController.SetAudioClip(tester ? _victorySound : _defeatSound);
            _backgroundMusicController.Start();
            GlobalUpgrades.instance.lives = GlobalUpgrades._startLives;
            GlobalUpgrades.instance.power = GlobalUpgrades._startPower;
            GlobalUpgrades.instance.speed = GlobalUpgrades._initialSpeed;
        }

        public void ActionMainMenu() => SceneManager.LoadScene(UnityScenes.Level1.ToString());
        
        public void ActionQuit() =>  Application.Quit();
    }
}