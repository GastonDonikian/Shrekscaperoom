using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour, IDamageable
{
    private const string CHARACTER_GAMEOBJECT_NAME = "Character";

    public ActorStats ActorStats => _actorStats;
    [SerializeField] private ActorStats _actorStats;
    
    public int MaxLife => _maxLife;
    [SerializeField] private int _maxLife;

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
        if (_currentLife > _maxLife)
        {
            _currentLife = _maxLife;
        }
    }
    
    public bool IsAlive() => _currentLife > 0;

    public void Die()
    {
        if (name == CHARACTER_GAMEOBJECT_NAME) EventManager.instance.ActionGameOver(false);
            Destroy(this.gameObject);
    }

    private void Start()
    {
        _maxLife = _actorStats.MaxLife;
        _currentLife = _maxLife;
    }
}
