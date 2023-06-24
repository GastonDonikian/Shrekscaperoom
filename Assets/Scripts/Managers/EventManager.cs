using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }

    public event Action<int> ActionCharacterLifeChange;
    public event Action<int> ActionCharacterSpeedChange;
    public event Action<bool> OnGameOver;
    public event Action<bool> OnChase;

    public event Action<int, int> ActionOnWeaponFired;
    public void ActionGameOver(bool isGameOver) => OnGameOver(isGameOver);
    public void StartChase(bool isDoorBroken) => OnChase(isDoorBroken);

    public void OnCharacterSpeedChange(int currentSpeed) => ActionCharacterSpeedChange(currentSpeed);

    public void OnWeaponFired(int currentAmmo, int maxAmmo) => ActionOnWeaponFired(currentAmmo, maxAmmo);

    public void OnCharacterLifeChange(int currentLife) => ActionCharacterLifeChange(currentLife);
}
