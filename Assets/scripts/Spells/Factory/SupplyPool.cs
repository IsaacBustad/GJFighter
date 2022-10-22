// Isaac Bustad
// 10/17/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// inherit pool functions and set type
public class SupplyPool : PoolGeneric<Sup9mmAmo>
{

    // vars
    protected static SupplyPool instance;
    // functions

    // accessors
    public static SupplyPool Instance { get { if (instance == null) { instance = new SupplyPool(); } return instance; } }
}
