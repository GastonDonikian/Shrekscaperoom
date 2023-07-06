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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        EventManager.instance.OnGameOver += OnGameOver;
        EventManager.instance.OnLvl2Over += OnLvl2Over;
    }
    


    private void OnGameOver(bool isVictory)
    {
        if (!isVictory && GlobalUpgrades.instance.lives > 0)
        {
                Invoke("LoadUpgradeScene", 0.5f);
        } else if (!isVictory)
        {
            GlobalVictory.instance.IsVictory = isVictory;
            Invoke("LoadEndGameScene", 0.5f);
        }
        else
        {
            SceneManager.LoadScene(UnityScenes.LoadLevel2Async.ToString());
        }
        
    }

    private void OnLvl2Over(bool isVictory)
    {
        if (!isVictory && GlobalUpgrades.instance.lives > 0)
        {
            GlobalUpgrades.instance.lives -= 1;
            SceneManager.LoadScene(UnityScenes.Level2.ToString());
            return;
        }
        GlobalVictory.instance.IsVictory = isVictory;
        Invoke("LoadEndGameScene", 0.5f);
    }

    private void LoadUpgradeScene()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(UnityScenes.UpgradeDeath.ToString());
    }

    private void LoadEndGameScene()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(UnityScenes.EndGame.ToString());
    }
}
  