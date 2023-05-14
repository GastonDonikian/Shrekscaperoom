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
        GlobalVictory.instance.IsVictory = isVictory;
        Invoke("LoadEndGameScene", 0.5f);
    }

    private void LoadEndGameScene() => SceneManager.LoadScene(UnityScenes.EndGame.ToString());
}
  