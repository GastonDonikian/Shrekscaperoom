using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLvl3Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "CharacterLvl3")
        {
            EventManager.instance.ActionLvl3Over(true);
            Destroy(gameObject);
        }
    }
}
