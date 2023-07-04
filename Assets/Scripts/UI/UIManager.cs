using System;
using System.Collections;
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
        [SerializeField] private Text _donkeysKilledValue;
        [SerializeField] private int _totalDonkeysKills;
        [SerializeField] private Image _transitionImage;

        private void Start()
        {
            var tempColor = _transitionImage.color;
            tempColor.a = 1f;
            _transitionImage.color = tempColor;

            OnCharacterPowerChange(GlobalUpgrades.instance.power);
            OnCharacterSpeedChange(GlobalUpgrades.instance.speed);
            OnCharacterLifeChange(GlobalUpgrades.instance.lives);
            OnDonkeyKilled(0);
            EventManager.instance.ActionCharacterSpeedChange += OnCharacterSpeedChange;
            EventManager.instance.ActionOnWeaponFired += OnWeaponFired;
            EventManager.instance.ActionDonkeyKilled += OnDonkeyKilled;
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

        private void OnDonkeyKilled(int currentKills)
        {
            _donkeysKilledValue.text = currentKills.ToString() + "/" + _totalDonkeysKills.ToString();
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