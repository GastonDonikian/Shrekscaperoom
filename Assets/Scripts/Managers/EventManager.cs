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
    
    public event Action<bool> OnGameOver;
    public void ActionGameOver(bool isGameOver) => OnGameOver(isGameOver);
}
