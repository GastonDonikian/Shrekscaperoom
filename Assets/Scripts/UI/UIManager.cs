﻿using System;
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
        [SerializeField] private List<Image> _lifeIcon;
        [SerializeField] private Image _weapon;
        [SerializeField] private Text _ammoValue;
        [SerializeField] private Text _powerValue;
        [SerializeField] private Text _speedValue;

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
            _speedValue.text = (int.Parse(_speedValue.text) + currentSpeed).ToString();

        }
        
        private void OnCharacterPowerChange(int currentPower)
        {

            _powerValue.text = currentPower.ToString();

        }
    }
}