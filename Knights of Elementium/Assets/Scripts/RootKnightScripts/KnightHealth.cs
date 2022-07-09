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
    public bool ItemHasDropped;
    int currentHealth;
    public int Armor;
    public int Strength;
    public int EarthResistance;
    public int FireResistance;
    public int WaterResistance;
    public int LightningResistance;
    public GameObject FogWallGrid;
    public GameObject RootArenaCommencer;
    public bool KnightDead;

    // Start is called before the first frame update

    void Start()
    {
        currentHealth = maxHealth;
        Healthbar.SetHealth(currentHealth, maxHealth);
        ItemHasDropped = false;
        Strength = 2;
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

                animator.SetTrigger("Hurt"); // play hurt animation

                Healthbar.SetHealth(currentHealth, maxHealth);

                CanBeDamaged = false;

                StartCoroutine(DamageCool());

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
