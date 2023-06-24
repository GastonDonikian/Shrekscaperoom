using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Character")
        {
            EventManager.instance.ActionGameOver(true);
            Destroy(gameObject);
        }
    }
}
