using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightHealth : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 200;
    public HealthbarBehaviorKnight Healthbar;
    public bool IsDead = false;
    public bool CanBeDamaged = true;
    public GameObject Enemy;
    public GameObject ItemDrop;
    public GameObject CopperCoin;
    public GameObject SilverCoin;
    public GameObject GoldCoin;
    public bool ItemHasDropped;
    int currentHealth;
    public int Armor;
    public int Strength;
    public int Weight;
    public int StaggerTime;
    public bool Staggered;
    public int EarthResistance;
    public int EarthPower;
    public int FireResistance;
    public int FirePower;
    public int WaterResistance;
    public int WaterPower;
    public int LightningResistance;
    public int LightningPower;
    public GameObject FogWallGrid;
    public GameObject RootArenaCommencer;
    public bool KnightDead;
    public GameObject FogOfWar;
    public GameObject Player;
    public GameObject HealthCanvas;
    public float StaggerThreshold;

    // Start is called before the first frame update

    public void HealthDisplay()
    {
        HealthCanvas.SetActive(true);
    }

    public void HealthDoNotDisplay()
    {
        HealthCanvas.SetActive(false);
    }

    void Start()
    {
        currentHealth = maxHealth;
        Healthbar.SetHealth(currentHealth, maxHealth);
        ItemHasDropped = false;
        Strength = 2;
        StaggerTime = 2;
        Weight = 1;
        EarthPower = 20;
        FirePower = 0;
        WaterPower = 0;
        LightningPower = 0;
        EarthResistance = 20;
        FireResistance = -20;
        WaterResistance = 5;
        LightningResistance = 5;
        KnightDead = false;
    }

    public void Revitalize ()
    {
        if (KnightDead == false)
        {
            currentHealth = maxHealth;
            Healthbar.SetHealth(currentHealth, maxHealth);
            FogWallGrid.SetActive(false);
            RootArenaCommencer.SetActive(true);
        }
    }

    public void TakeDamage(int damage)
    {
        if (IsDead == false)
        {
            if (CanBeDamaged == true)

            {
                currentHealth -= damage; // reduce hit points by damage amount
                StaggerThreshold += damage; //increase StaggerThreshold by damage amount
                Healthbar.SetHealth(currentHealth, maxHealth);

                CanBeDamaged = false;

                StartCoroutine(DamageCool());

                if (StaggerThreshold >= 100)
                {
                    animator.SetTrigger("Hurt"); // play hurt animation
                    StaggerThreshold = 0;
                }
                    if (currentHealth <= 0)
                {
                    Die();
                }
            }
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        FogOfWar.SetActive(false);

        KnightDead = true;

        IsDead = true;

        animator.SetBool("IsDead", true);
        
        GetComponent <CircleCollider2D>().enabled = false;

        GetComponent <Knight_Behavior>().enabled = false;                    

        this.enabled = false;

        transform.GetChild(0).gameObject.SetActive(false);

        transform.GetChild(1).gameObject.SetActive(false);

        transform.GetChild(2).gameObject.SetActive(false);

        transform.GetChild(3).gameObject.SetActive(false); // deactivates unwanted child objects after death

        transform.GetChild(1).GetComponent<TriggerAreaCheckKnights>().enabled = false;

        transform.GetChild(2).GetComponent<HotZoneCheckKnights>().enabled = false;

        transform.GetChild(2).GetComponent<HotZoneCheckKnights>().EnemyDeath(); // deactivates unwanted child script by changing boolean in child script (HotZone re-activating trigger area)

        FogWallGrid.SetActive(false);

        RootArenaCommencer.SetActive(false);

        if (ItemHasDropped == false)
        {
            Instantiate(ItemDrop, Enemy.transform.position + new Vector3(0, 0, -1), Enemy.transform.rotation);
            ItemHasDropped = true;
        }
    }
   
    public void Respawn()
    {
        Enemy.transform.position = new Vector3(2.55f, 17.34f, 1f);

        IsDead = false;

        animator.SetBool("IsDead", false);

        GetComponent<CircleCollider2D>().enabled = true;

        GetComponent<Knight_Behavior>().enabled = true;

        this.enabled = true;

        transform.GetChild(0).gameObject.SetActive(true);

        transform.GetChild(1).gameObject.SetActive(true);

        transform.GetChild(2).gameObject.SetActive(true);

        transform.GetChild(3).gameObject.SetActive(true); // deactivates unwanted child objects after death

        transform.GetChild(1).GetComponent<TriggerAreaCheckKnights>().enabled = true;

        transform.GetChild(2).GetComponent<HotZoneCheckKnights>().enabled = true;

        transform.GetChild(2).GetComponent<HotZoneCheckKnights>().EnemyRevival(); // reactivates unwanted child script by changing boolean in child script (HotZone re-activating trigger area)

        currentHealth = maxHealth;
        Healthbar.SetHealth(currentHealth, maxHealth);

    }

    IEnumerator DamageCool()
    {
        yield return new WaitForSeconds(0.5f);

        CanBeDamaged = true;
    }
}
