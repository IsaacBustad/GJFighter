// Isaac Bustad
// 10/22/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyFactory")]
public class EnemyFact : ScriptableObject
{
    // vars
    PoolGeneric<Enemy> pool = new PoolGeneric<Enemy>();
    [SerializeField] protected GameObject enemy;
    [SerializeField] protected Score score;

    // Update is called once per frame

    public GameObject SpawnEnemy(Vector3 aV3)
    {
        Enemy aEnemy = null;

        pool.ChPool(ref aEnemy);

        if (aEnemy != null)
        {
            return SpawnUsedEnemy(aEnemy, aV3);

        }
        else { return SpawnNewEnemy(aV3); }
    }

    protected GameObject SpawnNewEnemy(Vector3 aV3)
    {
        GameObject newEnemy = Instantiate(enemy, aV3, Quaternion.identity);
        Enemy enemC = newEnemy.GetComponent<Enemy>();
        enemC.Pool = pool;
        enemC.score = score;

        return newEnemy;
    }

    protected GameObject SpawnUsedEnemy(Enemy aEnemy, Vector3 aV3)
    {
        aEnemy.Activate(aV3);
        return aEnemy.gameObject;
    }
}
