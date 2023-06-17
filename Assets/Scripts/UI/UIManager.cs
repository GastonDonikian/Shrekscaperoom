using System;
using System.Collections.Generic;
using GlobalScripts;
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

        [SerializeField] private Image _weapon;
        [SerializeField] private Text _ammoValue;

        private void Start()
        {
            OnCharacterPowerChange(GlobalUpgrades.instance.power);
            OnCharacterSpeedChange(GlobalUpgrades.instance.speed);
            EventManager.instance.ActionCharacterSpeedChange += OnCharacterSpeedChange;
            EventManager.instance.ActionOnWeaponFired += OnWeaponFired;
        }

        private void OnWeaponFired(int currentAmmo, int maxAmmo)
        {
            _ammoValue.text = currentAmmo + "/" + maxAmmo;
        }

        private void OnCharacterSpeedChange(int currentSpeed)
        {
            int i = 0;
            foreach (var speedIcon in _speedIconList)
            {
                _speedDestroyAnimationList[i].enabled = (i == currentSpeed);
                if (i < currentSpeed)
                {
                    speedIcon.enabled = true;
                    _speedDestroyAnimationList[i].enabled = false;
                }
                else
                {
                    speedIcon.enabled = false;

                }


                i++;
            }
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