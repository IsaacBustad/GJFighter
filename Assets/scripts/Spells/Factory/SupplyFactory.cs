// Isaac Bustad
// 10/17/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SupFactory")]
public class SupplyFactory : ScriptableObject
{
    // vars
    PoolGeneric<Supply> pool = new PoolGeneric<Supply>();
    [SerializeField] protected GameObject sup;


    // functions
    /*public void SpawnSup(Vector3 aV3)
    {
        Supply aSup = null;

        pool.ChPool(ref aSup);

        if(aSup != null)
        {
            SpawnUsedSup(aSup, aV3);
            
        }
        else { SpawnNewSup(aV3); }
    }*/

    public GameObject SpawnSup(Vector3 aV3)
    {
        Supply aSup = null;

        pool.ChPool(ref aSup);

        if (aSup != null)
        {
            return SpawnUsedSup(aSup, aV3);

        }
        else { return SpawnNewSup(aV3); }
    }

    protected GameObject SpawnNewSup(Vector3 aV3)
    {
        GameObject newSup = Instantiate(sup, aV3, Quaternion.identity);
        Supply supC = newSup.GetComponent<Supply>();
        supC.Pool = pool;

        return newSup;
    }

    protected GameObject SpawnUsedSup(Supply aSup, Vector3 aV3)
    {
        aSup.Activate(aV3);
        return aSup.gameObject;
    }
    // accessors
}
