using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LordFarquad : MonoBehaviour
{
    private Rigidbody rb;
    private int left = 106;
    private int right = 131;

    private bool still = false;
    private bool lTR = true;
    private float stillTime = 0.2f;
    private void Update()
    {
        if (!still)
        {
            if (lTR)
            {
                transform.Translate(Vector3.forward * (13 * Time.deltaTime));
                if (right < transform.position.z)
                {
                    still = true;
                    lTR = false;
                }
            }
            else
            {
                transform.Translate(Vector3.back * (13 * Time.deltaTime));
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
                stillTime = 0.2f;
            }
            stillTime -= Time.deltaTime;
        }
    }
}
