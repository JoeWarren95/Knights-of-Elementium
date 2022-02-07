using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public HealthbarBehavior Healthbar;
    public bool IsDead = false;
    public bool CanBeDamaged = true;
    public GameObject Enemy;
    public GameObject CopperCoin;
    public GameObject SilverCoin;
    public GameObject GoldCoin;
    public GameObject ItemDrop;
    public bool ItemHasDropped;
    int currentHealth;
    public int Armor;
    public int Strength;
    public int Weight;
    public int StaggerTime;
    public bool Staggered;
    public int EarthResistance;
    public int FireResistance;
    public int WaterResistance;
    public int LightningResistance;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Healthbar.SetHealth(currentHealth, maxHealth);
        ItemHasDropped = false;
        Strength = 1;
        StaggerTime = 2;
        Weight = 1;
    }

    public void Revitalize ()
    {
        currentHealth = maxHealth;
        Healthbar.SetHealth(currentHealth, maxHealth);
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

        IsDead = true;

        Player.GetComponent<PlayerHealth>().InCombat = false;

        animator.SetBool("IsDead", true);
        
        GetComponent <CircleCollider2D>().enabled = false;

        GetComponent <Enemy_behavior>().enabled = false;                    

        this.enabled = false;

        transform.GetChild(0).gameObject.SetActive(false);

        transform.GetChild(1).gameObject.SetActive(false);

        transform.GetChild(2).gameObject.SetActive(false);

        transform.GetChild(3).gameObject.SetActive(false); // deactivates unwanted child objects after death

        transform.GetChild(5).gameObject.SetActive(false);
        
        transform.GetChild(1).GetComponent<TriggerAreaCheck>().enabled = false;

        transform.GetChild(2).GetComponent<HotZoneCheck>().enabled = false;

        transform.GetChild(2).GetComponent<HotZoneCheck>().EnemyDeath(); // deactivates unwanted child script by changing boolean in child script (HotZone re-activating trigger area)

        Instantiate(CopperCoin, Enemy.transform.position + new Vector3(0.09f, 0.3f, -1), Enemy.transform.rotation);
        Instantiate(CopperCoin, Enemy.transform.position + new Vector3(0.08f, 0.3f, -1), Enemy.transform.rotation);
        Instantiate(CopperCoin, Enemy.transform.position + new Vector3(0.07f, 0.3f, -1), Enemy.transform.rotation);
        Instantiate(CopperCoin, Enemy.transform.position + new Vector3(0.06f, 0.3f, -1), Enemy.transform.rotation);
        Instantiate(CopperCoin, Enemy.transform.position + new Vector3(0.09f, 0.3f, -1), Enemy.transform.rotation);
        Instantiate(CopperCoin, Enemy.transform.position + new Vector3(0.08f, 0.3f, -1), Enemy.transform.rotation);
        Instantiate(CopperCoin, Enemy.transform.position + new Vector3(0.07f, 0.3f, -1), Enemy.transform.rotation);
        Instantiate(CopperCoin, Enemy.transform.position + new Vector3(0.06f, 0.3f, -1), Enemy.transform.rotation);
        Instantiate(SilverCoin, Enemy.transform.position + new Vector3(0.1f, 0.3f, -1), Enemy.transform.rotation);
        Instantiate(SilverCoin, Enemy.transform.position + new Vector3(0.1f, 0.5f, -1), Enemy.transform.rotation);
        Instantiate(SilverCoin, Enemy.transform.position + new Vector3(0, 0.1f, -1), Enemy.transform.rotation);
        Instantiate(SilverCoin, Enemy.transform.position + new Vector3(0.05f, 0.05f, -1), Enemy.transform.rotation);
        Instantiate(GoldCoin, Enemy.transform.position + new Vector3(0.07f, 0.05f, -1), Enemy.transform.rotation);

        if (ItemHasDropped == false)
        {
            Instantiate(CopperCoin, Enemy.transform.position + new Vector3(0.09f, 0.3f, -1), Enemy.transform.rotation);
            Instantiate(CopperCoin, Enemy.transform.position + new Vector3(0.08f, 0.3f, -1), Enemy.transform.rotation);
            Instantiate(CopperCoin, Enemy.transform.position + new Vector3(0.07f, 0.3f, -1), Enemy.transform.rotation);
            Instantiate(CopperCoin, Enemy.transform.position + new Vector3(0.06f, 0.3f, -1), Enemy.transform.rotation);
            Instantiate(SilverCoin, Enemy.transform.position + new Vector3(-0.1f, 0.3f, -1), Enemy.transform.rotation);
            Instantiate(GoldCoin, Enemy.transform.position + new Vector3(-0.05f, 0.05f, -1), Enemy.transform.rotation);
            Instantiate(ItemDrop, Enemy.transform.position + new Vector3(0, 0, -1), Enemy.transform.rotation);
            ItemHasDropped = true;
        }
    }
   
    public void Respawn()
    {

        IsDead = false;

        animator.SetBool("IsDead", false);

        GetComponent<CircleCollider2D>().enabled = true;

        GetComponent<Enemy_behavior>().enabled = true;

        this.enabled = true;

        transform.GetChild(0).gameObject.SetActive(true);

        transform.GetChild(1).gameObject.SetActive(true);

        transform.GetChild(2).gameObject.SetActive(true);

        transform.GetChild(3).gameObject.SetActive(true); // deactivates unwanted child objects after death

        transform.GetChild(5).gameObject.SetActive(true);

        transform.GetChild(1).GetComponent<TriggerAreaCheck>().enabled = true;

        transform.GetChild(2).GetComponent<HotZoneCheck>().enabled = true;

        transform.GetChild(2).GetComponent<HotZoneCheck>().EnemyRevival(); // reactivates unwanted child script by changing boolean in child script (HotZone re-activating trigger area)

        currentHealth = maxHealth;
        Healthbar.SetHealth(currentHealth, maxHealth);

    }

    IEnumerator DamageCool()
    {
        yield return new WaitForSeconds(0.5f);

        CanBeDamaged = true;
    }
}
