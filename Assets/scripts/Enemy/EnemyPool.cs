using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : PoolGeneric<Enemy>
{
    // vars
    protected static EnemyPool instance;
    // functions

    // accessors
    public static EnemyPool Instance { get { if (instance == null) { instance = new EnemyPool(); } return instance; } }
}
