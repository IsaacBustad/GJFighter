// Isaac Bustad
// 10/10/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    // vars


    // functions
    protected void Start()
    {
        maxHealth = 100f;
        curHealth = maxHealth;
    }

    public override void TakeDamage(float aDamage)
    {
        curHealth -= aDamage;
        OutOfHealth();
    }

    protected void OutOfHealth()
    {
        if (curHealth <= 0)
        {
            SceneManager.LoadScene("Credits");
        }
    }

    

    // accessors


}
