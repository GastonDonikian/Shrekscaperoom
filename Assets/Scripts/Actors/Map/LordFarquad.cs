using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LordFarquad : MonoBehaviour
{
    private Rigidbody rb;
    private int left = 97;
    private int right = 143;

    private bool still = false;
    private bool lTR = true;
    private float stillTime = 0.5f;
    private void Update()
    {
        if (!still)
        {
            if (lTR)
            {
                transform.Translate(Vector3.forward * (15 * Time.deltaTime));
                if (right < transform.position.z)
                {
                    still = true;
                    lTR = false;
                }
            }
            else
            {
                transform.Translate(Vector3.back * (15 * Time.deltaTime));
                if (left > transform.position.z)
                {
                    still = true;
                    lTR = true;
                }
            }
        }
        else
        {
            if (stillTime <= 0 )
            {
                still = false;
                stillTime = 0.5f;
            }
            stillTime -= Time.deltaTime;
        }
    }
}
