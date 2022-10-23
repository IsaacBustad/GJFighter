// Isaac Bustad
// 10/22/2021


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected PoolGeneric<Enemy> pool = new PoolGeneric<Enemy>();
    [SerializeField] protected int points = 5;
    public Score score;
    public bool headLeft = true;
    protected float speed = 6;

    // vars
    [SerializeField] protected string idStr = "Base1";

    [SerializeField] protected float phisDamage = 10;
    [SerializeField] protected Sprite sprite;/*= Resources.Load()*/

    [SerializeField] protected GameObject effectGO;


    //protected Package package = null;
    protected int isPlayer = 10;
    protected int isBooundry = 8;

    protected void FixedUpdate()
    {
        MoveLeft();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == isPlayer)
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(phisDamage);
        }
        if(collision.gameObject.layer == isBooundry)
        {
            AddToPool();
        }
    }

    public void DefeatEnemy()
    {
        score.ScorePoints = points;
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

    protected void MoveLeft()
    {
        gameObject.transform.Translate(Vector3.left * Time.fixedDeltaTime * speed);
    }

    // accessors
    public PoolGeneric<Enemy> Pool { get { return pool; } set { pool = value; } }
}
