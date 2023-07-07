using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingFloor : MonoBehaviour
{
    private bool collided = false;
    private Rigidbody rb;
    private float toRise = 9f;
    private float start;
    private bool trig = false;
    
    [SerializeField] private AudioClip _rise;
    
    public AudioSource AudioSource => _audioSource;
    private AudioSource _audioSource;
    
    public void OnCollisionEnter(Collision collision)
    {
        //if collided with character give character damage
        if (collision.gameObject.layer == 6 && !trig)
        {
            trig = true;
            Invoke("SetCollided", 0.5f);
        }
    }

    private void SetCollided()
    {
        collided = true;
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        _audioSource.PlayOneShot(_rise);
    }

    private void Update()
    {
        if (collided)
        {
            if (transform.position.y < start + toRise)
            {
                transform.Translate(Vector3.up * (10 * Time.deltaTime));
            }
            else
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }

    private void Start()
    {
        start = transform.position.y;
        rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }
}
