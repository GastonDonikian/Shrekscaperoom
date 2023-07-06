using System;
using System.Collections;
using System.Collections.Generic;
using GlobalScripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManagerLevel2 : MonoBehaviour
    {
        [SerializeField] private List<Image> _lifeIcon;
        [SerializeField] private Image _transitionImage;
        [SerializeField] private GameObject _character;
        private LifeController _characterLifeController;
        [SerializeField] private Text _timeLeft;
        [SerializeField] private AudioSource fiveSecondsLeft;
        [SerializeField] private AudioSource NoSecondsLeft;
        private void Start()
        {
            _characterLifeController = _character.GetComponent<LifeController>();
            var tempColor = _transitionImage.color;
            tempColor.a = 1f;
            _transitionImage.color = tempColor;
            
            OnCharacterLifeChange(GlobalUpgrades.instance.lives);
            StartCoroutine("ChangeStartingOverlay");
        }

        private void Update()
        {
            
            _timeLeft.text = _characterLifeController.CurrentLife.ToString() + "s";
            if (_characterLifeController.CurrentLife == 6)
            {
                fiveSecondsLeft.PlayOneShot(fiveSecondsLeft.clip);
            }

            if (_characterLifeController.CurrentLife == 1)
            {
                NoSecondsLeft.PlayOneShot(fiveSecondsLeft.clip);
            }
        }

        IEnumerator ChangeStartingOverlay()
        {
            while(_transitionImage.color.a > 0){
                var tempColor = _transitionImage.color;
                tempColor.a -= 0.005f;
                _transitionImage.color = tempColor;
                yield return null;
            }
        }
        
        private void OnCharacterLifeChange(int currentLife)
        {
            var i = 0;

            foreach (var listIcon in _lifeIcon)
            {
                if (i < currentLife)
                {
                    listIcon.enabled = true;
                    listIcon.GetComponentInChildren<Image>().enabled = true;
                }
                else
                {
                    listIcon.GameObject().SetActive(false);
                }
                i++;
            }
        }
    }
}