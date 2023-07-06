using System;
using System.Collections;
using System.Collections.Generic;
using GlobalScripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManagerLevel3 : MonoBehaviour
    {
        [SerializeField] private List<Image> _lifeIcon;
        [SerializeField] private Text _ammoValue;
        [SerializeField] private Image _transitionImage;

        private void Start()
        {
            var tempColor = _transitionImage.color;
            tempColor.a = 1f;
            _transitionImage.color = tempColor;

            _ammoValue.text = "1/1";
            OnCharacterLifeChange(GlobalUpgrades.instance.lives);
            EventManager.instance.ActionOnWeaponFired += OnWeaponFired;
            StartCoroutine("ChangeStartingOverlay");
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

        private void OnWeaponFired(int currentAmmo, int maxAmmo)
        {
            _ammoValue.text = currentAmmo + "/" + maxAmmo;
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