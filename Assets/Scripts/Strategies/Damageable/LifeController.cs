using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class LifeController : MonoBehaviour, IDamageable
{
    public const string CHARACTER_GAMEOBJECT_NAME = "Character";
    private const string DOOR_GAMEOBJECT_NAME = "Door";
    private const string CDOOR_GAMEOBJECT_NAME = "Connected Door";
    public int MaxLife => GetComponent<Actor>().ActorStats.MaxLife;
    public int CurrentLife => _currentLife;
    [SerializeField] private int _currentLife;

    public void TakeDamage(int damage)
    {
        _currentLife -= damage;
        if (!IsAlive())
        {
            Die();
        }
    }

    public void RecoverLife(int recoverAmount)
    {
        _currentLife += recoverAmount;
        if (_currentLife > MaxLife)
        {
            _currentLife = MaxLife;
        }
    }
    
    public bool IsAlive() => _currentLife > 0;

    public void Die()
    {
        if (name == CHARACTER_GAMEOBJECT_NAME) 
            EventManager.instance.ActionGameOver(false);
        else if (name == DOOR_GAMEOBJECT_NAME || name == CDOOR_GAMEOBJECT_NAME)
            EventManager.instance.StartChase(true);
        Destroy(this.gameObject);
    }

    private void Start()
    {
        _currentLife = MaxLife;
    }
}
