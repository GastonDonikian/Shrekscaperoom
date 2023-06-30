using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Sounds;
using UnityEngine;

public class LifeController : MonoBehaviour, IDamageable
{
    public const string CHARACTER_GAMEOBJECT_NAME = "Character";
    private const string DOOR_GAMEOBJECT_NAME = "Door";
    private const string CDOOR_GAMEOBJECT_NAME = "Connected Door";
    private const string MACHINE_GAMEOBJECT_NAME = "Machine_3";
    private const string DONKEY_GAMEOBJECT_NAME = "Donkey(Clone)";
    [SerializeField] private SoundDamageEffectController _soundDamageEffectController;
    
    [SerializeField] private GameObject _explosionFxPrefab;

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
        else if (name == DONKEY_GAMEOBJECT_NAME)
            EventManager.instance.OnDonkeyKilled();
        else if (name == DOOR_GAMEOBJECT_NAME || name == CDOOR_GAMEOBJECT_NAME)
            EventManager.instance.StartChase(true);
        else if (name == MACHINE_GAMEOBJECT_NAME)
        {
            Instantiate(_explosionFxPrefab, transform.position, transform.rotation, transform);
            _soundDamageEffectController.OnDamage();
            Invoke("DestroyMachine", 0.7f);
            return;
        }
        Destroy(this.gameObject);
    }
    
    private void DestroyMachine()
    {
        Destroy(this.gameObject);
    }

    private void Start()
    {
        _currentLife = MaxLife;
    }
}
