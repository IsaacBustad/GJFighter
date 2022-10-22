// Isaac Bustad
// 10/22/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    protected Enemy enemy;

    protected void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
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
            enemy = gameObject.GetComponent<Enemy>();
            enemy.DefeatEnemy();
        }
    }
}
