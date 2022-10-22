// Isaac Bustad
// 9/17/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Supply : MonoBehaviour
{
    protected PoolGeneric<Supply> pool;

    // vars
    [SerializeField] protected string idStr = "Base1";

    [SerializeField] protected int slot = 1;
    [SerializeField] protected int units = 1;
    [SerializeField] protected float cost = 1f;
    [SerializeField] protected Sprite sprite;/*= Resources.Load()*/

    [SerializeField] protected GameObject effectGO;


    //protected Package package = null;
    protected int isPlayer = 8;

    protected abstract void OnCollisionEnter(Collision collision);
    

    protected void CollectSup()
    {
        //SupEffect seffect = effectGO.GetComponent<SupEffect>();
        //seffect.CollectSup();

        AddToPool();
    }

    protected void DammageSup()
    {
        //SupEffect seffect = effectGO.GetComponent<SupEffect>();
        //seffect.DammageSup();
        AddToPool();
    }

    protected void AddToPool() 
    { 
        Pool.AddToPool(this);
        //package.RevSups(gameObject);
        gameObject.SetActive(false);
    }

    public void Activate(Vector3 aV3)
    {
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = aV3;
    }

    // accessors
    public string IDStr { get { return idStr; } }
    public int Slots{ get { return slot; } }
    public float Cost{ get { return cost; } }
    public int Units { get { return units; } }
    public Sprite Sprite{ get { return sprite; } }
    public PoolGeneric<Supply> Pool { get { return pool; } set { pool = value; } }
    //public Package Package{ get { return package; } set { package = value; } }
}
