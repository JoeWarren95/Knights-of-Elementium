using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int maxStamina = 100;
    public int maxMana = 100;
    public int currentHealth;
    public int currentStamina;
    public int currentMana;
    public int HealthRegen = 10;
    public int StaminaRegen = 10;
    public int ManaRegen = 10;
    public int StaminaTax;
    public int ManaTax;
    public float HealthTimer = 1;
    public float StaminaTimer = 1;
    public float ManaTimer = 1;
    public float DeathTimer = 3;
    public Animator animator;
    public PHealthBar healthBar;
    public PStaminaBar staminaBar;
    public PManaBar manaBar;
    public bool CanBeDamaged;
    public bool IsDead;
    public GameObject PlayerTag;
    public GameObject Player;
    public GameObject Mask;
    public GameObject Enemy;
    public GameObject RootKnight;
    public GameObject Inventory;
    public GameObject InventorySystem;
    public GameObject CurrencySystem;
    public int StaminaCost = 20;
    public int ManaCost = 20;
    public int Weight;
    public Rigidbody2D rb;
    public Text HealthText;
    public Text StaminaText;
    public Text ManaText;
    public bool InCombat;
    public bool OpenBook;
    public GameObject SpellBook;
    public int CurrencyPenalty;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentMana = maxMana;
        healthBar.SetMaxHealth(maxHealth);
        staminaBar.SetMaxStamina(maxStamina);
        manaBar.SetMaxMana(maxMana);
        CanBeDamaged = true;
        InCombat = false;
    }

    // Update is called once per frame
    void Update()
    {
        maxHealth = 100 + Player.GetComponent<PlayerAttributes>().Vigor;
        maxStamina = 100 + Player.GetComponent<PlayerAttributes>().Stamina;
        maxMana = 100 + Player.GetComponent<PlayerAttributes>().Mana;
        Weight = Player.GetComponent<PlayerAttributes>().Weight;
        StaminaTax = StaminaCost - Player.GetComponent<PlayerAttributes>().StaminaTax;
        ManaTax = ManaCost - Player.GetComponent<PlayerAttributes>().ManaTax;
        HealthRegen = 1 + Player.GetComponent<PlayerAttributes>().Vitality;
        StaminaRegen = 10 + Player.GetComponent<PlayerAttributes>().Endurance;
        ManaRegen = 1 + Player.GetComponent<PlayerAttributes>().Brilliance;
        HealthText.text = currentHealth.ToString();
        StaminaText.text = currentStamina.ToString();
        ManaText.text = currentMana.ToString();
        CurrencyPenalty = 30;
        rb.gravityScale = 3 + 0.1f * Weight; // Player weight --> gravity modifier


        if (InCombat == true)
        {
            Inventory.SetActive(false);
            InventorySystem.GetComponent<InventoryManager>().CloseInventory();
        }

        if (InCombat == false)
        {
            Inventory.SetActive(true);
        }

        if (currentStamina >= maxStamina)
        {
            currentStamina = maxStamina;
        }
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentMana >= maxMana)
        {
            currentMana = maxMana;
        }
        if (currentHealth <= 0 && IsDead == false)
        {
            Die();
            Mask.GetComponent<MaskManager>().MaskShatter7();
            IsDead = true;
        }
        if (currentHealth <= 15 && 0 <= currentHealth)
        {
            Mask.GetComponent<MaskManager>().MaskShatter6();
        }
        if (currentHealth <= 30 && 15 <= currentHealth)
        {
            Mask.GetComponent<MaskManager>().MaskShatter5();
        }
        if (currentHealth <= 50 && 30 <= currentHealth)
        {
            Mask.GetComponent<MaskManager>().MaskShatter4();
        }
        if (currentHealth <= 75 && 50 <= currentHealth)
        {
            Mask.GetComponent<MaskManager>().MaskShatter3();
        }
        if (currentHealth <= 99 && 75 <= currentHealth)
        {
            Mask.GetComponent<MaskManager>().MaskShatter2();
        }
        if (currentHealth == 100)
        {
            Mask.GetComponent<MaskManager>().MaskShatter1();
        }
        if (currentHealth < maxHealth && InCombat == true) // condition for health to regenerate
        {
            HealthTimer -= 1 * Time.deltaTime; // Regen frequency
        }
        if (currentStamina < maxStamina) // condition for stamina to regenerate
        {
            StaminaTimer -= 1 * Time.deltaTime; // Regen frequency
        }
        if (currentMana < maxMana && InCombat == true) // condition for mana to regenerate
        {
            ManaTimer -= 1 * Time.deltaTime; // Regen frequency
        }
        if (HealthTimer <= 0)
        {
            HealthTimer = 1;
            HealthRegeneration();
        }
        if (StaminaTimer <= 0)
        {
            StaminaTimer = 1;
            StaminaRegeneration();
        }
        if (ManaTimer <= 0)
        {
            ManaTimer = 1;
            ManaRegeneration();
        }
        if (IsDead == true)
        {
            DeathTimer -= 1 * Time.deltaTime;
        }
        if (DeathTimer <= 0)
        {
            DeathTimer = 3;
            Respawn();
        }
    }

    void HealthRegeneration()
    {
        {
            currentHealth += HealthRegen; // inrease health by regen amount
            healthBar.SetHealth(currentHealth);
        }
    }
    void StaminaRegeneration ()
    {
        {
            currentStamina += StaminaRegen; // inrease stamina by regen amount
            staminaBar.SetStamina(currentStamina);
        }
    }
    void ManaRegeneration()
    {
        {
            currentMana += ManaRegen; // inrease mana by regen amount
            manaBar.SetMana(currentMana);
        }
    }
    void Respawn()
    {
        Player.transform.position = new Vector3(-36f, 4f, -1f);
        Player.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -1.0f, 0f);
        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.GetComponent<CharacterController2D>().enabled = true;
        Player.GetComponent<PlayerCombat>().enabled = true;
        IsDead = false;
        currentHealth = 100;
        PlayerTag.SetActive(true);
        animator.SetBool("IsDead", false);
        healthBar.SetHealth(currentHealth);
        Enemy.GetComponent<EnemyHealth>().Respawn();
    }
    void Die() // Everything that happens/is disabled when the player dies
    {
        Player.GetComponent<Rigidbody2D>().velocity =new Vector3(0f, -1.0f, 0f);
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<CharacterController2D>().enabled = false;
        Player.GetComponent<PlayerCombat>().enabled = false;
        IsDead = true;
        PlayerTag.SetActive (false);
        animator.SetBool("IsDead", true);
        CurrencySystem.GetComponent<Currency>().DeathPenalty();
    }

    public void TaxStamina()
    {
        currentStamina -= StaminaTax; // reduce stamina by tax amount
        staminaBar.SetStamina(currentStamina);
    }
    public void TaxMana()
    {
        currentMana -= ManaTax; // reduce mana by tax amount
        manaBar.SetMana(currentMana);
    }

    public void TakeDamage(int damage)
    { 
        if(CanBeDamaged == true)
        
        {
            currentHealth -= (damage); // reduce hit points by damage amount minus armor stat

            animator.SetTrigger("IsHurt"); // play hurt animation

            healthBar.SetHealth(currentHealth);

            CanBeDamaged = false;

            StartCoroutine(DamageCool());
        }
    }

    public void Rest()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentMana = maxMana;
        healthBar.SetHealth(currentHealth);
        staminaBar.SetStamina(currentStamina);
        manaBar.SetMana(currentMana);
        Enemy.GetComponent<EnemyHealth>().Respawn();
        RootKnight.GetComponent<KnightHealth>().Respawn();
        GetComponent<PlayerMovement>().IsResting = true;
    }
        IEnumerator DamageCool() // Time before player can take damage again after being damaged
    {
        yield return new WaitForSeconds(1f);

        CanBeDamaged = true;
    }
}
