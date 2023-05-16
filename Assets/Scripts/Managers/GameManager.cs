using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using GlobalScripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    

    private void Start()
    {
        EventManager.instance.OnGameOver += OnGameOver;
    }
    


    private void OnGameOver(bool isVictory)
    {
        if (GlobalUpgrades.instance.GetLives() > 0)
        {
            Invoke("LoadUpgradeScene", 0.5f);
        }
        else
        {
            GlobalVictory.instance.IsVictory = isVictory;
            Invoke("LoadEndGameScene", 0.5f);            
        }

    }

    private void LoadUpgradeScene() => SceneManager.LoadScene(UnityScenes.UpgradeDeath.ToString());
    private void LoadEndGameScene() => SceneManager.LoadScene(UnityScenes.EndGame.ToString());
}
  