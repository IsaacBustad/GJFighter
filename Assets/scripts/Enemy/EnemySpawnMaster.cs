// Isaac Busatd
// 10/22/2022
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnMaster : MonoBehaviour
{
    // vars
    // delays
    [SerializeField] protected float timeBtwRnds = 5f;
    [SerializeField] protected float timeBtwSpawns = 0.3f;
    [SerializeField] protected float timeToDelay = 1f;
    [SerializeField] protected float timeToIncrease = 1.5f;

    // clock
    // 
    [SerializeField] protected float timeFromLastSpawn;
    [SerializeField] protected float timeFromLastWave;

    // enemies to spawn
    [SerializeField] protected int enemiesToWave = 1;
    [SerializeField] protected int enemiesForWave = 1;
    [SerializeField] protected float enemyIncrease = 1.5f;

    // locations
    [SerializeField] protected List<Transform> spawnPTs;

    // enemy prefab
    [SerializeField] protected List<EnemyFact> enemiesLst;
    



    // functions
    protected void FixedUpdate()
    {
        timeFromLastSpawn += Time.fixedDeltaTime;
        timeFromLastWave += Time.fixedDeltaTime;
        timeFromLastSpawn += Time.fixedDeltaTime;


        NextWave();
        StagerSpawn();
    }

    protected void NextWave()
    {
        if(timeFromLastWave >= timeBtwRnds)
        {
            timeFromLastWave = 0;
            timeBtwRnds *= timeToIncrease;
            enemiesForWave = enemiesToWave;

            enemiesToWave *= Convert.ToInt32(timeToIncrease * enemiesToWave);
        }

    }


    protected void StagerSpawn()
    {
        if (timeFromLastSpawn >= (timeBtwRnds - 0.5f) / enemiesToWave) 
        {
            SpawnEnemy();
        }
    }

    protected void SpawnEnemy()
    {
        if (enemiesForWave > 0)
        {
            int randpos = UnityEngine.Random.Range(0, spawnPTs.Count - 1);
            int randIdx = UnityEngine.Random.Range(0, enemiesLst.Count - 1);

            enemiesLst[randIdx].SpawnEnemy(spawnPTs[randpos].position);
            enemiesForWave--;
        }
        
    }

    




    // accessors
}
