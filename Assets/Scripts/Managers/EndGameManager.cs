using System;
using GlobalScripts;
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
        private void Start()
        {
            _background.sprite = GlobalVictory.instance.IsVictory ? _victory : _defeat;
        }

        public void ActionMainMenu() => SceneManager.LoadScene(UnityScenes.Menu.ToString());
    }
}