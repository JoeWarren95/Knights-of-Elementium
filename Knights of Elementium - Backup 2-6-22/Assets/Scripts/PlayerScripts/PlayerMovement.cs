using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 100f;
    public float horizontalMove = 0f;
    public bool isFalling = false;
    public bool CanJump = true;
    public bool jump = false;
    public bool crouch = false;
    public bool IsJumping = false;
    public bool IsRunning = false;
    public float jumpRate = 2f;
    public float nextJumpTime = 0f;
    public float CurrentTime = 1;
    public float RunningTime = 0;
    public float IdleTime = 0;
    public bool CanDoubleJump;
    public bool CanRun;
    public Rigidbody2D rb;
    public float DoubleJumpPower;
    public bool IsDoubleJumping;
    public bool IsIdling;
    public float FallingTime;
    public GameObject Player;
    public float StaggerTime = 0;
    public bool Staggered = false;
    public bool IsResting;
    public bool JustRested;
    public float JustRestedTime = 1;

    void Update() {


        if (JustRested == true)
        {
            JustRestedTime -= 2 * Time.deltaTime;
        }
        if (JustRestedTime <= 0)
        {
            JustRestedTime = 1;
            JustRested = false;
        }
        if (IsResting == true)
        {
            animator.SetBool("IsResting", true);
        }
        if (IsResting == false)
        {
            animator.SetBool("IsResting", false);
        }
        if (isFalling == true)
        {
            FallingTime -= 1 * Time.deltaTime;
        }
        if (isFalling == false)
        {
            FallingTime = 10;
        }
        if (FallingTime <= 0)
        {
            FallingTime = 10;
            Player.GetComponent<PlayerHealth>().currentHealth = 0;
        }
        if (crouch == true)
        {
            IdleTime = 0;
            runSpeed = 25;
            IsIdling = false;
        }

        if (Staggered == true)
        {
            StaggerTime -= 1 * Time.deltaTime;
            runSpeed = 0;
        }

        if (StaggerTime <= 0)
        {
            StaggerTime = 1;
            Staggered = false;
            runSpeed = 10;
        }

 
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (horizontalMove == 0 && GetComponent<PlayerCombat>().IsAttacking == false && crouch == false && GetComponent<PlayerHealth>().IsDead == false)
        {
            IsIdling = true;
            runSpeed = 40f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            IsIdling = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            IsIdling = false;
        }
        if (Input.GetKey(KeyCode.D) && IsResting == true)
        {
            JustRested = true;
            IsResting = false;
        }
        if (Input.GetKey(KeyCode.A) && IsResting == true)
        {
            JustRested = true;
            IsResting = false;
        }
        if (IsIdling == true && Player.GetComponent<PlayerHealth>().IsDead == false)
        {
            IdleTime -= 1 * Time.deltaTime;
        }
        if (IsIdling == false)
        {
            animator.SetBool("LongIdle", false);
        }
        if (IdleTime < -2.75)
        {
            animator.SetBool("LongIdle", true);
        }
        if (IdleTime < -5.0)
        {
            animator.SetBool("LongLongIdle", true);
            IdleTime = 0;
        }
        if (GetComponent<DashMove>().Attacking == true)
        {
            runSpeed = 0;
            RunningTime = 0;
        }

        if (horizontalMove <= -10 && crouch == false && isFalling == false)
        {
            IsRunning = true;
            IsIdling = false;
            IdleTime = 0;
        }

        if (horizontalMove >= 10 && crouch == false && isFalling == false)
        {
            IsRunning = true;
            IsIdling = false;
            IdleTime = 0;
        }

        if (horizontalMove == 0 && GetComponent<DashMove>().Attacking == false)
        {
            IsRunning = false;
            RunningTime = 0;
            runSpeed = 10;
        }

        if (IsRunning == true && GetComponent<DashMove>().Attacking == false && crouch == false)
        {
            RunningTime -= 1 * Time.deltaTime;
        }

        if (RunningTime <= 0 && -0.033 <= RunningTime && GetComponent<DashMove>().Attacking == false && IsRunning == true)
        {
            runSpeed = 10;
        }

        if (RunningTime <= -0.033 && -0.075 <= RunningTime && GetComponent<DashMove>().Attacking == false && IsRunning == true)
        {
            runSpeed = 20;
        }

        if (RunningTime <= -0.075 && -0.1 <= RunningTime && GetComponent<DashMove>().Attacking == false && IsRunning == true)
        {
            runSpeed = 30;
        }

        if (RunningTime <= -0.1 && -0.8 <= RunningTime && GetComponent<DashMove>().Attacking == false && IsRunning == true)
        {
            runSpeed = 40;
        }

        if (RunningTime <= -0.8 && -2 <= RunningTime && GetComponent<DashMove>().Attacking == false && IsJumping == false && IsDoubleJumping == false && IsRunning == true)
        {
            runSpeed = 50;
        }

        if (RunningTime <= -2 && -3 <= RunningTime && GetComponent<DashMove>().Attacking == false && IsJumping == false && IsDoubleJumping == false && IsRunning == true)
        {
            runSpeed = 60;
        }

        if (RunningTime <= -3 && -4 <= RunningTime && GetComponent<DashMove>().Attacking == false && IsJumping == false && IsDoubleJumping == false && IsRunning == true)
        {
            runSpeed = 70;
        }
        if (RunningTime <= -4 && -5 <= RunningTime && GetComponent<DashMove>().Attacking == false && IsJumping == false && IsDoubleJumping == false && IsRunning == true)
        {
            runSpeed = 80;
        }
        if (RunningTime <= -5 && -6 <= RunningTime && GetComponent<DashMove>().Attacking == false && IsJumping == false && IsDoubleJumping == false && IsRunning == true)
        {
            runSpeed = 90;
        }



        if (Input.GetButtonDown("Jump"))
        { 
            if (CanDoubleJump == true && Player.GetComponent<PlayerHealth>().currentStamina >= 20)
            {
                rb.velocity = Vector2.up * DoubleJumpPower;
                CurrentTime = 0;
                IsDoubleJumping = true;
                CanJump = false;
                IsRunning = false;
                IsIdling = false;
                IdleTime = 0;
                animator.SetTrigger("DoubleJump"); // play air jump or double jump animation
                Player.GetComponent<PlayerHealth>().TaxStamina();
            }
        }


            if (CurrentTime <= -1)
        {
            CanDoubleJump = true;
        }
       
        if (CurrentTime == 0 && isFalling == false)
        {
            CanDoubleJump = false;
        }
       
        if (IsJumping == false)
        {
            CurrentTime = 0;
        }
        if (IsDoubleJumping == true)
        {
            CanJump = false;
        }

        if (IsJumping == true && IsDoubleJumping == false)
        {
            CurrentTime -= 8 * Time.deltaTime;
            CanJump = false;
        }

        { 
            if(Time.time >= nextJumpTime)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    if (crouch == false)
                    {
                        if (isFalling == false)
                        {
                            if (CanJump == true && Player.GetComponent<PlayerHealth>().currentStamina >= 20 && Player.GetComponent<PlayerCombat>().IsAttacking == false)
                            {
                                jump = true;
                                animator.SetBool("IsJumping", true);
                                IsJumping = true;
                                CanJump = false;
                                IsRunning = false;
                                IsIdling = false;
                                IdleTime = 0;
                                nextJumpTime = Time.time + 1.5f / jumpRate;
                                Player.GetComponent<PlayerHealth>().TaxStamina();
                            }
                        }
                    }
                }
            }
        }

        if (IsJumping == true)
        {
            IsIdling = false;
            CanJump = false;
        }
        
        if (nextJumpTime <= Time.time)
        {
            IsJumping = false;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            CanJump = false;
            GetComponent<CharacterController2D>().CrouchActive = true;
        } else if (Input.GetButtonUp("Crouch") && isFalling == false && IsJumping == false && IsDoubleJumping == false)
        {
            crouch = false;
            CanJump = true;
            GetComponent<CharacterController2D>().CrouchActive = false;
        }
        if (GetComponent<Rigidbody2D>().velocity.y < -1.3)
        {
            animator.SetBool("IsFalling", true);

            isFalling = true;
            IsIdling = false;
            CanJump = false;
            IdleTime = 0;
        }
        else
        {
            animator.SetBool("IsFalling", false);

            isFalling = false;
        }
        if (GetComponent<Rigidbody2D>().velocity.y > 1.3)
        {
            animator.SetBool("IsJumping", true);
            IsRunning = false;
        }
        if (GetComponent<Rigidbody2D>().velocity.y >= 0)
        {
            animator.SetBool("IsFalling", false);

            isFalling = false;
        }
        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            animator.SetBool("IsJumping", false);
        }
    }

public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
public void Stagger()
    {
        StaggerTime = 1;
    }

    void FixedUpdate()
    {
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }
    }
}
