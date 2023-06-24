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
    }
    


    private void OnGameOver(bool isVictory, string cause)
    {
        if (!isVictory && GlobalUpgrades.instance.lives > 0)
        {
                Invoke("LoadUpgradeScene", 0.5f);
                return; }
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
  