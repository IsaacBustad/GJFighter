// Isaac Bustad
// 10/20/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    protected PoolGeneric<Spell> pool;

    // vars
    [SerializeField] protected float damage = 50;

    [SerializeField] protected GameObject effectGO;
    protected GameObject spell;

    protected int isPlayer = 10;
    protected int isEnemy = 11;

    public bool headLeft;

    protected float speed = 6;

    

    protected void Update()
    {
        if (headLeft)
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == isPlayer)
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        if (collision.gameObject.layer == isEnemy)
        {
            
        }
    }
    protected void DealDammage(Health aHealth)
    {
        aHealth.TakeDamage(damage);
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
    }

    // accessors
    public PoolGeneric<Spell> Pool { get { return pool; } set { pool = value; } }
}
