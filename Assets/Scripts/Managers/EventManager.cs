using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public int _donkeyCount;
    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }

    public event Action<int> ActionCharacterLifeChange;
    public event Action<int> ActionCharacterSpeedChange;
    public event Action<bool> OnGameOver;

    public event Action<bool> OnMiss;
    public event Action<bool> OnLvl2Over;
    public event Action<bool> OnLvl3Over;
    public event Action<bool> OnChase;

    public event Action<int, int> ActionOnWeaponFired;

    public event Action<int> ActionDonkeyKilled;

    public void OnDonkeyKilled()
    {
        instance._donkeyCount += 1;
        instance.ActionDonkeyKilled(instance._donkeyCount);
    }

    public void ActionGameOver(bool isGameOver) => OnGameOver(isGameOver);
    
    public void ActionMiss(bool isMiss) => OnMiss(isMiss);
    
    public void ActionLvl2Over(bool isGameOver) => OnLvl2Over(isGameOver);
    public void ActionLvl3Over(bool isGameOver) => OnLvl3Over(isGameOver);
    public void StartChase(bool isDoorBroken) => OnChase(isDoorBroken);

    public void OnCharacterSpeedChange(int currentSpeed) => ActionCharacterSpeedChange(currentSpeed);

    public void OnWeaponFired(int currentAmmo, int maxAmmo) => ActionOnWeaponFired(currentAmmo, maxAmmo);

    public void OnCharacterLifeChange(int currentLife) => ActionCharacterLifeChange(currentLife);
}
