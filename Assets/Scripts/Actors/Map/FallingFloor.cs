using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    private bool collided = false;
    private Rigidbody rb;
    public void OnCollisionEnter(Collision collision)
    {
        //if collided with character give character damage
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("MBEHH");
            Invoke("SetCollided", 1f);
        }
    }

    private void SetCollided()
    {
        collided = true;
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        if (collided)
        {
            transform.Translate(Vector3.down * (2 * Time.deltaTime));
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
