using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    //properties
    GameObject BulletPrefab { get; }
    int Damage { get; }
    int MagSize { get; }
    int CurrentBulletCount { get; }
    float ShotCooldown { get; }
    float ReloadCooldown { get; }
    

    //actions
    bool Attack();
    bool Reload();
}
