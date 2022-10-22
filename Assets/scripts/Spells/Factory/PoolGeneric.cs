// Isaac Bustad
// 10/12/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolGeneric<T>
{

    // vars
    protected Queue<T> aPool = new Queue<T>();

    // functions
    public void AddToPool(T aPoolable)
    {
        aPool.Enqueue(aPoolable);
    }

    protected T RevFromPool()
    {
        T aPoolable = aPool.Dequeue();
        return aPoolable;
    }

    public void ChPool(ref T aPoolable)
    {
        //Debug.Log("Check pool");
        if (aPool.Count > 0)
        {
            //Debug.Log("Pool entered");
            T foundAmo = RevFromPool();
            aPoolable = foundAmo;
            
        }

    }

    // accessors
}
