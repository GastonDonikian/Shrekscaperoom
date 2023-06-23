using System;
using System.Collections.Generic;
using GlobalScripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Image _avatar;
        [SerializeField] private Image _lifeBar;
        [SerializeField] private List<Image> _speedIconList;
        [SerializeField] private List<Image> _speedDestroyAnimationList;
        [SerializeField] private List<Image> _powerIcon;
        [SerializeField] private List<Image> _lifeIcon;
        [SerializeField] private Image _weapon;
        [SerializeField] private Text _ammoValue;

        private void Start()
        {
            OnCharacterPowerChange(GlobalUpgrades.instance.power);
            OnCharacterSpeedChange(GlobalUpgrades.instance.speed);
            OnCharacterLifeChange(GlobalUpgrades.instance.lives);
            EventManager.instance.ActionCharacterSpeedChange += OnCharacterSpeedChange;
            EventManager.instance.ActionOnWeaponFired += OnWeaponFired;
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
        private void OnCharacterSpeedChange(int currentSpeed)
        {
            var i = 0;
            foreach (var listIcon in _speedIconList)
            {   
                if (i < currentSpeed)
                    listIcon.enabled = true;
                else
                {
                    listIcon.enabled = false;
                }
                i++;
            }

            // foreach (var speedIcon in _speedIconList)
            // {
            //     _speedDestroyAnimationList[i].enabled = (i == currentSpeed);
            //     if (i < currentSpeed)
            //     {
            //         speedIcon.enabled = true;
            //         _speedDestroyAnimationList[i].enabled = false;
            //     }
            //     else
            //     {
            //         speedIcon.enabled = false;
            //
            //     }
            //
            //
            //     i++;
            // }
        }
        
        private void OnCharacterPowerChange(int currentPower)
        {
            
            var i = 0;
            foreach (var powerIcon in _powerIcon)
            {   
                if (i < currentPower)
                    powerIcon.enabled = true;
                else
                {
                    powerIcon.enabled = false;
                }
                i++;
            }
            
        }
    }
}