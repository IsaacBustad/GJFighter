// Isaac Bustad 
// 8/23/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    // vars
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float curHealth;


    // functions
    public abstract void TakeDamage(float aDamage);

    // accessors
    public float MaxHealth { get { return maxHealth; } }
    public float CurHealth { get { return curHealth; } }

    public virtual void HealDamage(float aDamage)
    {
        curHealth += aDamage;
    }

    public void ToFullHealth()
    {
        curHealth = maxHealth;
    }

}
