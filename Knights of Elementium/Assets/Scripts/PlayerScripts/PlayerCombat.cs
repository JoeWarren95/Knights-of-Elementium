using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public float attackRate = 1f;
    float nextAttackTime = 0f;
    public int PlayerAttackDamage = 25;
    public int PlayerFireDamage;
    public int PlayerEarthDamage;
    public int PlayerWaterDamage;
    public int PlayerLightningDamage;
    public GameObject Player;
    float HorizontalInput;
    public Rigidbody2D rb;
    public bool IsAttacking;
    public float ComboTime = 2;
    public bool JustAttacked;
    public bool CanAttack;

    void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");

        PlayerAttackDamage = 25 + Player.GetComponent<PlayerAttributes>().Strength;
        PlayerEarthDamage = 25 + Player.GetComponent<PlayerAttributes>().EarthPower;
        PlayerFireDamage = 25 + Player.GetComponent<PlayerAttributes>().FirePower;
        PlayerWaterDamage = 25 + Player.GetComponent<PlayerAttributes>().WaterPower;
        PlayerLightningDamage = 25 + Player.GetComponent<PlayerAttributes>().LightningPower;

        if (JustAttacked == true)
        {
            ComboTime -= 3 * Time.deltaTime;
        }
        if (ComboTime <= 0)
        {
            ComboTime = 2;
            JustAttacked = false;
        }
        if (IsAttacking == true)
        {
            Player.GetComponent<PlayerMovement>().runSpeed = 0f;
            Player.GetComponent<PlayerMovement>().IsIdling = false;
            Player.GetComponent<PlayerMovement>().IdleTime = 1;
        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (GetComponent<PlayerMovement>().IsJumping == false && GetComponent<PlayerMovement>().IsDoubleJumping == false && Player.GetComponent<PlayerHealth>().currentStamina >= 20 && Player.GetComponent<PlayerMovement>().Staggered == false)
                {
                    StartCoroutine(Attack());
                    nextAttackTime = Time.time + 2.3f / attackRate;
                }
            }
        }
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (GetComponent<PlayerMovement>().IsJumping == false && GetComponent<PlayerMovement>().IsDoubleJumping == false && Player.GetComponent<PlayerHealth>().currentStamina >= 20 && Player.GetComponent<PlayerMovement>().Staggered == false)
                {
                    StartCoroutine(VerticalAttack());
                    nextAttackTime = Time.time + 2.3f / attackRate;
                }
            }
        }
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (GetComponent<PlayerMovement>().IsJumping == true && Player.GetComponent<PlayerHealth>().currentStamina >= 20 && Player.GetComponent<PlayerMovement>().Staggered == false)
                {
                    StartCoroutine(JumpingVerticalAttack());
                    nextAttackTime = Time.time + 2.3f / attackRate;
                }
            }
        }
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (GetComponent<PlayerMovement>().IsDoubleJumping == true && Player.GetComponent<PlayerHealth>().currentStamina >= 20 && Player.GetComponent<PlayerMovement>().Staggered == false)
                {
                    StartCoroutine(JumpingVerticalAttack());
                    nextAttackTime = Time.time + 2.3f / attackRate;
                }
            }
        }
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (GetComponent<PlayerMovement>().IsJumping == true && Player.GetComponent<PlayerHealth>().currentStamina >= 20 && Player.GetComponent<PlayerMovement>().Staggered == false)
                {
                    StartCoroutine(UpJumpingVerticalAttack());
                    nextAttackTime = Time.time + 2.3f / attackRate;
                }
            }
        }
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (GetComponent<PlayerMovement>().IsDoubleJumping == true && Player.GetComponent<PlayerHealth>().currentStamina >= 20 && Player.GetComponent<PlayerMovement>().Staggered == false)
                {
                    StartCoroutine(UpJumpingVerticalAttack());
                    nextAttackTime = Time.time + 2.3f / attackRate;
                }
            }
        }
    }
    IEnumerator VerticalAttack()
    {
        Player.GetComponent<DashMove>().Attacking = true;

        Player.GetComponent<PlayerMovement>().runSpeed = 1;

        IsAttacking = true;

        animator.SetTrigger("VerticalAttack"); // play vertical attack animation

        animator.SetBool("IsAttacking", true);

        yield return new WaitForSeconds(0.3f);

        Player.GetComponent<PlayerHealth>().TaxStamina();

        Player.GetComponent<DashMove>().VerticalAttackDash();

        yield return new WaitForSeconds(0.2f);

        JustAttacked = true;

        IsAttacking = false;

        animator.SetBool("IsAttacking", false);



        Player.GetComponent<DashMove>().Attacking = false;

    }
    IEnumerator Attack()
    {
        Player.GetComponent<DashMove>().Attacking = true;

        Player.GetComponent<PlayerMovement>().runSpeed = 1;

        IsAttacking = true;

        animator.SetTrigger("Attack"); // play attack animation

        animator.SetBool("IsAttacking", true); // set bool in animator

        yield return new WaitForSeconds(0.3f);

        Player.GetComponent<DashMove>().HorizontalAttackDash();

        Player.GetComponent<PlayerHealth>().TaxStamina();

        yield return new WaitForSeconds(0.2f);

        Player.GetComponent<PlayerMovement>().runSpeed = 10;

        JustAttacked = true;

        Player.GetComponent<DashMove>().Attacking = false;

        IsAttacking = false;

        animator.SetBool("IsAttacking", false);


    }

    IEnumerator JumpingVerticalAttack()
    {

        animator.SetTrigger("VerticalJumpingAttack"); // play vertical attack animation

        IsAttacking = true;

        Player.GetComponent<DashMove>().UpwardFloat();

        yield return new WaitForSeconds(0.7f);
        
        Player.GetComponent<PlayerHealth>().TaxStamina();
        
        Player.GetComponent<DashMove>().JumpingVerticalAttackDash();

        IsAttacking = false;

        yield return new WaitForSeconds(0.3f);

        Player.GetComponent<PlayerMovement>().RunningTime = 0;


    }

    IEnumerator UpJumpingVerticalAttack()
    {
        if (Player.GetComponent<PlayerMovement>().isFalling == false)
        {
            animator.SetTrigger("UpJumpingAttackUp"); // play vertical attack up animation

            yield return new WaitForSeconds(0.3f);

            Player.GetComponent<PlayerHealth>().TaxStamina();

            Player.GetComponent<DashMove>().UpJumpingAttackDash();

            yield return new WaitForSeconds(0.7f);
        }
        else if (Player.GetComponent<PlayerMovement>().isFalling == true)
            {
            animator.SetTrigger("UpJumpingAttackDown"); // play vertical attack down animation

            yield return new WaitForSeconds(0.3f);

            Player.GetComponent<PlayerHealth>().TaxStamina();

            Player.GetComponent<DashMove>().UpJumpingAttackDash();

            yield return new WaitForSeconds(0.7f);
        }
    }

        IEnumerator HorizontalComboAttack()
    {
        IsAttacking = true;

        animator.SetTrigger("HorizontalCombo"); // play attack animation

        yield return new WaitForSeconds(0.7f);

        Player.GetComponent<DashMove>().HorizontalAttackDash();

        Player.GetComponent<PlayerHealth>().TaxStamina();

        ComboTime = 2;

        IsAttacking = false;

        yield return new WaitForSeconds(0.3f);
    }
    IEnumerator VerticalComboAttack()
    {
        IsAttacking = true;

        animator.SetTrigger("VerticalCombo"); // play attack animation

        yield return new WaitForSeconds(0.3f);

        Player.GetComponent<DashMove>().VerticalAttackDash();

        Player.GetComponent<PlayerHealth>().TaxStamina();

        ComboTime = 2;
        
        IsAttacking = false;

        yield return new WaitForSeconds(0.4f);
    }
}
