// Isaac Bustad
// 10/22/2021


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected PoolGeneric<Enemy> pool;
    protected int points;
    public Score score;
    public bool headLeft = true;

    // vars
    [SerializeField] protected string idStr = "Base1";

    [SerializeField] protected float phisDamage = 10;
    [SerializeField] protected Sprite sprite;/*= Resources.Load()*/

    [SerializeField] protected GameObject effectGO;


    //protected Package package = null;
    protected int isPlayer = 10;

    
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == isPlayer)
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(phisDamage);
        }
    }

    public void DefeatEnemy()
    {
        //SupEffect seffect = effectGO.GetComponent<SupEffect>();
        //seffect.DammageSup();
        AddToPool();
    }

    protected void AddToPool()
    {
        pool.AddToPool(this);
        //package.RevSups(gameObject);
        gameObject.SetActive(false);

    }

    public void Activate(Vector3 aV3)
    {
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = aV3;
        this.gameObject.GetComponent<EnemyHealth>().ToFullHealth();
    }

    // accessors
    public PoolGeneric<Enemy> Pool { get { return pool; } set { pool = value; } }
}
