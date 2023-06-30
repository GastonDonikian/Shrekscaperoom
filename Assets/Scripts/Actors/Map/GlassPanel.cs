using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPanel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int _totalDonkeysKills;
    void Start()
    {
        EventManager.instance.ActionDonkeyKilled += OnDonkeyKilled;
    }

    // Update is called once per frame
    private void OnDonkeyKilled(int currentKills)
    {
        if (currentKills >= _totalDonkeysKills) Destroy(this.gameObject);
    }
}
