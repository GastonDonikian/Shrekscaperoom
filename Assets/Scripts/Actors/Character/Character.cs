using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;


public enum Weapons
{
    Pistol = 0,
    Shotgun = 1,
    Machingun = 2
}
public class Character : MonoBehaviour
{

    [SerializeField] private List<Gun> _availableWeapons;
    [SerializeField] private Gun _currentWeapon;

    [SerializeField] private MovementController _movementController;
    // private LifeController _lifeController;
    
    // public float MovementSpeed => _movementSpeed;
    // [SerializeField] private float _movementSpeed;
    //
    // public float RotationSpeed => _rotateSpeed;
    // [SerializeField] private float _rotateSpeed;

    
    //Mvmt commands
    private CmdMovement _cmdMoveForward;
    private CmdMovement _cmdMoveBackward;
    private CmdRotation _cmdRotateLeft;
    private CmdRotation _cmdRotateRight;
    
    //Weapon cmds
    private CmdAttack _cmdAttack;
    private CmdReload _cmdReload;
    
    

    void Start()
    {
        EquipWeapon(Weapons.Pistol);
        _movementController = GetComponent<MovementController>();
        // _lifeController = GetComponent<LifeController>();

        _cmdAttack = new CmdAttack(_currentWeapon);
        _cmdReload = new CmdReload(_currentWeapon);

    }

    void Update()
    {
        //Move forward
        if (Input.GetKey(KeyCode.W))
        {
            EventQueueManager.instance.AddEvent(new CmdMovement(_movementController,transform.forward));
        }
        //Move back
        if (Input.GetKey(KeyCode.S)) EventQueueManager.instance.AddEvent( new CmdMovement(_movementController,-transform.forward));

        //Move left
        if (Input.GetKey(KeyCode.A)) EventQueueManager.instance.AddEvent(new CmdRotation(_movementController,-transform.up));
        //Move right
        if (Input.GetKey(KeyCode.D)) EventQueueManager.instance.AddEvent(new CmdRotation(_movementController,transform.up));

        //shoot
        if (Input.GetAxis("Fire1") > 0) EventQueueManager.instance.AddEvent(_cmdAttack);
        if (Input.GetKey(KeyCode.R)) EventQueueManager.instance.AddEvent(_cmdReload);

        //action equip weapons
        if (Input.GetKeyDown(KeyCode.Alpha1)) EquipWeapon(Weapons.Pistol);
        if (Input.GetKeyDown(KeyCode.Alpha2)) EquipWeapon(Weapons.Shotgun);
        if (Input.GetKeyDown(KeyCode.Alpha3)) EquipWeapon(Weapons.Machingun);

        if (Input.GetKeyDown(KeyCode.F1)) EventManager.instance.ActionGameOver(true);
        // if (Input.GetKeyDown(KeyCode.F2)) _lifeController.TakeDamage(50);

    }

    private void EquipWeapon(Weapons weapon)
    {
        foreach (Gun gun in _availableWeapons)
        {
            gun.gameObject.SetActive(false);
        }
        
        _currentWeapon = _availableWeapons[(int)weapon];
        _currentWeapon.gameObject.SetActive(true);
        
        _cmdAttack = new CmdAttack(_currentWeapon);
        _cmdReload = new CmdReload(_currentWeapon);
    }
}
