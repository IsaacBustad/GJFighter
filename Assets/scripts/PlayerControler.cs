// Isaac Busatd
// 10/21/2021


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    private float speed = 8f;
    private float defaultSpeed = 8f;
    private float sprintSpeed = 16f;
    private float crouchSpeed = 4f;
    private float jumpingPower = 8f;
    private bool isFacingRight = true;

    private double lastLeftTap;
    private double lastRightTap;
    private double tapTimeout = 1;

    void Update()
    {
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;


        CheckForDash(context);
    }

    protected void CheckForDash(InputAction.CallbackContext context)
    {
        if(horizontal > 0 && context.started)
        {
            if (context.startTime - lastRightTap < tapTimeout)
            {
                speed = sprintSpeed;
            }
            lastRightTap = context.startTime;
        }

        if (horizontal < 0 && context.started)
        {
            if (context.startTime - lastLeftTap < tapTimeout)
            {
                speed = sprintSpeed;
            }
            lastLeftTap = context.startTime;
        }


    }

}
