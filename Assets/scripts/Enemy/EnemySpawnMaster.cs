// Isaac Busatd
// 10/22/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnMaster : MonoBehaviour
{
    // vars
    // delays
    [SerializeField] protected float timeBtwRnds = 5f;
    [SerializeField] protected float timeToDelay = 1f;

    // clock
    [SerializeField] protected float timeFromLastSpawn;
    [SerializeField] protected float timeFromLastWave;

    // enemies to spawn
    [SerializeField] protected int enemiesToWave = 1;
    [SerializeField] protected int enemiesForWave = 1;
    



    // functions
    protected void FixedUpdate()
    {
        timeFromLastSpawn += Time.fixedDeltaTime;
        timeFromLastWave += Time.fixedDeltaTime;
    }

    protected void NextWave()
    {
        if(timeFromLastWave >= timeBtwRnds)
        {
            timeFromLastWave = 0;
        }

    }


    protected void StagerSpawn()
    {

    }



    // accessors
}
