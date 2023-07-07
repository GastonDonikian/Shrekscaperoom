using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    private bool collided = false;
    private Rigidbody rb;
    
    public AudioSource AudioSource => _audioSource;
    private AudioSource _audioSource;
    
    [SerializeField] private AudioClip _fall;
    public void OnCollisionEnter(Collision collision)
    {
        //if collided with character give character damage
        if (collision.gameObject.layer == 6)
        {
            Invoke("SetCollided", 0.5f);
        }
    }

    private void SetCollided()
    {
        collided = true;
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        _audioSource.PlayOneShot(_fall);
    }

    private void Update()
    {
        if (collided)
        {
            Debug.Log("collided");
            transform.Translate(Vector3.down * (2 * Time.deltaTime));
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }
}
