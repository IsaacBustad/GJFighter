// Isaac Busatd
// 10/21/2021


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public Rigidbody2D rb;
    protected Stanima stanima;
    // public Transform groundCheck;
    //public LayerMask groundLayer;

    private float horizontal;
    private float vertical;
    private float speed = 8f;
    //private float defaultSpeed = 8f;
    //private float sprintSpeed = 16f;
    //private float crouchSpeed = 4f;
    //private float jumpingPower = 8f;
    //private bool isFacingRight = true;

    private double lastLeftTap;
    private double lastRightTap;
    private double tapTimeout = 1;

    public bool headLeft = false;

    [SerializeField] protected float spellCost = 10;

    // spells
    [SerializeField] GameObject firingPT;
    [SerializeField] SpellFactory spell1;


    // reset score vars
    [SerializeField] Score score;

    private void Start()
    {
        score.ClearScore();
        rb.freezeRotation = true;
        stanima = GetComponent<Stanima>();
    }
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    public void CastSpell(InputAction.CallbackContext context)
    {

    }


    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (stanima.GiveStamina(spellCost) == spellCost)
            {
                spell1.SpawnSpell(firingPT.transform.position, headLeft);
            }
        }
      
    }

    

}
