using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float VerticalAttackDashSpeed;
    public float HorizontalAttackDashSpeed;
    public float JumpingVerticalAttackDashSpeed;
    public float UpJumpingAttackDashSpeed;
    public float UpwardFloatMagnitude;
    public float DashSpeed;
    public float dashTime;
    public float startDashTime;
    public int direction;
    public Animator animator;
    public bool Attacking;
    public GameObject Player;
    public bool IsDashing;
    public float TimeDashing = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        direction = 2;
    }

    void Update()
    {
        if (IsDashing == true)
        {
            TimeDashing -= 5 * Time.deltaTime;
            Player.GetComponent<PlayerHealth>().CanBeDamaged = false;
        }
        if (TimeDashing <= 0)
        {
            TimeDashing = 1;
            IsDashing = false;
            Player.GetComponent<PlayerHealth>().CanBeDamaged = true;
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        { 
                Dash();
        }
        if (Input.GetKey(KeyCode.D) && GetComponent <PlayerMovement>().IsResting == false && !Input.GetKey(KeyCode.A) && direction != 2 && GetComponent<PlayerCombat>().IsAttacking == false && GetComponent<PlayerMovement>().IsJumping == false && GetComponent<PlayerMovement>().IsDoubleJumping == false && GetComponent<PlayerMovement>().crouch == false && !animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Falling") && GetComponent<PlayerHealth>().IsDead == false && IsDashing == false && GetComponent<PlayerMovement>().JustRested == false)
        {
            animator.SetTrigger("FaceSwitch");
        }
        if (Input.GetKey(KeyCode.A) && GetComponent<PlayerMovement>().IsResting == false && !Input.GetKey(KeyCode.D) && direction != 1 && GetComponent<PlayerCombat>().IsAttacking == false && GetComponent<PlayerMovement>().IsJumping == false && GetComponent<PlayerMovement>().IsDoubleJumping == false && GetComponent<PlayerMovement>().crouch == false && !animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Falling") && GetComponent<PlayerHealth>().IsDead == false && IsDashing == false && GetComponent<PlayerMovement>().JustRested == false)
        {
            animator.SetTrigger("FaceSwitch");
        }
        if (Input.GetKey(KeyCode.A) && direction != 1 && !Input.GetKey(KeyCode.D) && GetComponent<PlayerCombat>().IsAttacking == false)
        {
            direction = 1;
        }
        
        else if (Input.GetKey(KeyCode.D) && direction != 2 && !Input.GetKey(KeyCode.A) && GetComponent<PlayerCombat>().IsAttacking == false)
        {
            direction = 2;
        }
        if (dashTime <= 0)
        {
            dashTime = startDashTime;
        }
    }

    public void HorizontalAttackDash()
    {

        if (dashTime <= 0)
        {
            direction = 0;
            dashTime = startDashTime;
            rb.velocity = Vector2.zero;
        }
        else
        {
            dashTime -= Time.deltaTime;

            if (direction == 1)
            {
                rb.velocity = Vector2.left * HorizontalAttackDashSpeed;
            }
            else if (direction == 2)
            {
                rb.velocity = Vector2.right * HorizontalAttackDashSpeed;
            }
        }
    }
   
    public void VerticalAttackDash()
    {

        if (dashTime <= 0)
        {
            direction = 0;
            dashTime = startDashTime;
            rb.velocity = Vector2.zero;
        }
        else
        {
            dashTime -= Time.deltaTime;

            if (direction == 1)
            {
                rb.velocity = Vector2.left * VerticalAttackDashSpeed;
            }
            else if (direction == 2)
            {
                rb.velocity = Vector2.right * VerticalAttackDashSpeed;
            }
        }
    }

    public void JumpingVerticalAttackDash()
    {

        if (dashTime <= 0)
        {
            direction = 0;
            dashTime = startDashTime;
            rb.velocity = Vector2.zero;
        }
        else
        {
            dashTime -= Time.deltaTime;

            if (direction == 1)
            {
                rb.velocity = Vector2.down * JumpingVerticalAttackDashSpeed;
            }
            else if (direction == 2)
            {
                rb.velocity = Vector2.down * JumpingVerticalAttackDashSpeed;
            }
        }
    }

    public void UpJumpingAttackDash()
    {

        if (dashTime <= 0)
        {
            direction = 0;
            dashTime = startDashTime;
            rb.velocity = Vector2.zero;
        }
        else
        {
            dashTime -= Time.deltaTime;

            if (direction == 1)
            {
                rb.velocity = Vector2.up * UpJumpingAttackDashSpeed;
            }
            else if (direction == 2)
            {
                rb.velocity = Vector2.up * UpJumpingAttackDashSpeed;
            }
        }
    }

    public void UpwardFloat()
    {

        if (dashTime <= 0)
        {
            direction = 0;
            dashTime = startDashTime;
            rb.velocity = Vector2.zero;
        }
        else
        {
            dashTime -= Time.deltaTime;

            if (direction == 1)
            {
                rb.velocity = Vector2.up * UpwardFloatMagnitude;
            }
            else if (direction == 2)
            {
                rb.velocity = Vector2.up * UpwardFloatMagnitude;
            }
        }
    }

        public void Dash()
    {

        if (dashTime <= 0)
        {
            direction = 0;
            dashTime = startDashTime;
            rb.velocity = Vector2.zero;
        }
        else if (Attacking == false && Player.GetComponent<PlayerHealth>().currentStamina >= 20)
        {
            dashTime -= Time.deltaTime;

            if (direction == 1)
            {
                rb.velocity = Vector2.left * DashSpeed;
                animator.SetTrigger("Dashing"); // play Dash animation
                Player.GetComponent<PlayerHealth>().TaxStamina();
                IsDashing = true;
            }
            else if (direction == 2)
            {
                rb.velocity = Vector2.right * DashSpeed;
                {
                    animator.SetTrigger("Dashing"); // play Dash animation
                    Player.GetComponent<PlayerHealth>().TaxStamina();
                    IsDashing = true;
                }
            }
        }
    }
}