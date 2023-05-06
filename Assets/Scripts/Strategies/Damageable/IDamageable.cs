using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    //properties
    int CurrentLife { get; }
    
    //actions
    void TakeDamage(int damage);
    void RecoverLife(int recoverAmount);
    
    bool IsAlive();
    void Die();
}
