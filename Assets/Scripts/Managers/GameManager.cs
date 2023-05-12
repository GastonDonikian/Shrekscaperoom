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
    [SerializeField] private bool _isGameOver = false;
    [SerializeField] private bool _isVictory = false;

    private void Start()
    {
        EventManager.instance.OnGameOver += OnGameOver;
    }

    private void OnGameOver(bool isVictory)
    {
        _isGameOver = true;
        _isVictory = isVictory;
        Invoke("LoadEndGameScene", 3);
    }

    private void LoadEndGameScene() => SceneManager.LoadScene(UnityScenes.EndGame.ToString());
}
  