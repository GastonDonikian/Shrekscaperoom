using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false;
    [SerializeField] private bool _isVictory = false;
    [SerializeField] private Text _gameOverMessage;

    private void Start()
    {
        EventManager.instance.OnGameOver += OnGameOver;
        _gameOverMessage.text = String.Empty;
    }

    private void OnGameOver(bool isVictory)
    {
        _isGameOver = true;
        _isVictory = isVictory;
        _gameOverMessage.text = _isVictory ? "Victory!" : "Defeat";
        _gameOverMessage.color = _isVictory ? Color.green : Color.red;
    }
}
