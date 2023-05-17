using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LifeTimeController))]
public class Bullet : MonoBehaviour, IBullet, IMovable
{

    private LifeTimeController _lifeTimeController;
    
    public float LifeTime => _lifeTime;
    [SerializeField] private float _lifeTime = 3f;


    public float MovementSpeed => _movementSpeed;
    [SerializeField] private float _movementSpeed = 20f;

    [SerializeField] private List<int> _layerMask;

    public int Damage { get; set; }
    
    public void Travel() => Move(Vector3.forward);
    
    public void Move(Vector3 direction) => transform.Translate(direction * (Time.deltaTime * MovementSpeed));
    public void ReduceSpeed(int speed)
    {
        throw new NotImplementedException();
    }

    public void IncreaseSpeed(int speed)
    {
        throw new NotImplementedException();
    }


    // Start is called before the first frame update
    void Start()
    {
        _lifeTimeController = GetComponent<LifeTimeController>();
        _lifeTimeController.SetLifeTime(LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        Travel();
        if (_lifeTimeController.IsLifeTimeOver()) Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("Bullet has died");
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (_layerMask.Contains(collision.gameObject.layer))
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null) EventQueueManager.instance.AddEvent(new CmdApplyDamage(damageable, Damage));
            Destroy(gameObject);
        }
        
    }
}