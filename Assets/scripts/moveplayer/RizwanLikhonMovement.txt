using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RizwanLikhonMovement : MonoBehaviour
{ 
    [SerializeField] private float walkspeed;
    [SerializeField] private float runspeed;
    [SerializeField] private float jumpspeed;
    [SerializeField] private float crouchspeed;
    [SerializeField] private float damage;
    private BoxCollider2D bc;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool walking;
    private bool crouching;
    private bool attacking;
    



    private void Awake()
    {
        // Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bc= GetComponent<BoxCollider2D>();
        //enemyhealth= GetComponent<EnemyHealth>();
    }

    private void Update()
    {


        float horizontalInput;
        body.velocity = new Vector2(horizontalInput * runspeed, body.velocity.y);
        //bc.size = new Vector2(0.4553795f, 0.4839265f);

        //flip player when moving left-right

        if (horizontalInput=Input.Getkey(KeyCode.D)  > 0.01f)
            transform.localScale = new Vector3(130, 170, 1);
        else if (horizontalInput = Input.Getkey(KeyCode.A) < -0.01f)
            transform.localScale = new Vector3(-130, 170, 1);

        /*
        if (horizontalInput = Input.Getkey(KeyCode.K) > 0.01f)
            transform.localScale = new Vector3(130, 170, 1);
        else if (horizontalInput = Input.Getkey(KeyCode.L) < -0.01f)
            transform.localScale = new Vector3(-130, 170, 1);*/

        if ((Input.GetKey(KeyCode.Space))||(Input.GetKey(KeyCode.Enter)) && grounded)
        {
            Jump();
        }

        
        if(Input.GetKeyDown(KeyCode.C) && grounded)
        {
            Crouch();

        }
        if(Input.GetKeyUp(KeyCode.C)&&grounded)
        {
            bc.size = new Vector2(0.4553795f, 0.4839265f);
            bc.offset = new Vector2(0.07783809f, -0.02496272f);

        }
        if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.I))
        {
            NormalAttack();
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K))
        {
            UltimateAttack();
        }


        // set animoator peremeters
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
        anim.SetBool("walking", walking);
        anim.SetBool("crouching", crouching);
        anim.SetBool("attacking", attacking);


    }
    //Jump Methods
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpspeed);
        anim.SetTrigger("jump");
        grounded = false;

    }
    
   
    private void Crouch()
    {
        float horizontalInput;
        body.velocity = new Vector2(horizontalInput * crouchspeed, body.velocity.y);
        bc.size = new Vector2(0.4553795f, 0.25394f);
        bc.offset = new Vector2(0.0778380f, -0.139956f);



        //flip player when moving left-right

        if (horizontalInput = Input.Getkey(KeyCode.D) > 0.01f)
            transform.localScale = new Vector3(130, 170, 1);
        else if (horizontalInput = Input.Getkey(KeyCode.A) < -0.01f)
            transform.localScale = new Vector3(-130, 170, 1);

        //anim.ResetTrigger("crouch");
        /*
        if(Input.GetKeyUp(KeyCode.C))
        {
            anim.ResetTrigger("crouch");
        }*/
    }
    private void NormalAttack()
    {
        if(!grounded)
        {
            body.gravityScale = 110;
            
        }
        anim.SetTrigger("attack");
        attacking=true;
        //anim.ResetTrigger("attack");
    }
    private void UltimateAttack()
    {
        if (!grounded)
        {
            body.gravityScale = 110;

        }
        anim.SetTrigger("attack");
        attacking = true;
        //anim.ResetTrigger("attack");
    }
    //When Entering Collision

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Wall")
        {
            body.gravityScale = 950;
            body.mass = 1000;
            grounded = false;
        }
        else if (collision.gameObject.tag == "Ground")
        {
            grounded = true;

        }

       
        
        

    }
    //When staying with other game object with collision
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            body.gravityScale = 1500;
            body.mass = 1000;


        }
        

    }
    // after exiting the collision with other object
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            body.gravityScale = 70;
            grounded = true;

        }

       
        else if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }


    }
    
    
    

}
