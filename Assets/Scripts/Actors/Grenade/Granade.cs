using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] private GameObject _explosionFxPrefab;
    [SerializeField] private float _delay = 3f;
    [SerializeField] private float _fxdelay = 2f;
    [SerializeField] private float _radius = 5f;
    [SerializeField] private float _explosionForce = 500f;
    private float _countdown;

    private bool _hasExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        _countdown = _delay;
    }

    // Update is called once per frame
    void Update()
    {
        //cuenta regresiva
        _countdown -= Time.deltaTime;
        //trigger explosion
        if (_countdown <= 0f && !_hasExploded)
        {
            _hasExploded = true;
            Explosion();
        }
    }

    private void Explosion()
    {
        //instancia visual effect
        Instantiate(_explosionFxPrefab, transform.position, transform.rotation, transform);
        //encontrar objetos cercanos
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
        foreach (Collider c in colliders)
        {
            //aplicar fuerza
            Rigidbody rb = c.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(_explosionForce, transform.position, _radius);
            }
            //aplicar daño
            IDamageable damageable = c.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage((int)_explosionForce/ 10);
            }
        }
        this.enabled = false;
        Debug.Log("BOOOOM!");
        Invoke("DestroyGranade", _fxdelay);
    }

    private void DestroyGranade() => Destroy(this.GameObject());
}
