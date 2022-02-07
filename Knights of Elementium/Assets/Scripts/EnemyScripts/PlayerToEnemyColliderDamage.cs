using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToEnemyColliderDamage : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject FloatingText;
    public GameObject FloatingEarthText;
    public GameObject FloatingFireText;
    public GameObject FloatingWaterText;
    public GameObject FloatingLightningText;
    public int PlayerDamage; // Base damage of Player from Player Combat
    public int EarthDamage; // Base earth damage of Player from Player Combat
    public int FireDamage; // Base fire damage of Player from Player Combat
    public int WaterDamage; // Base water damage of Player from Player Combat
    public int LightningDamage; // Base lightning damage of Player from Player Combat


    void Update()
    {
       PlayerDamage = GameObject.Find("Player").GetComponent<PlayerCombat>().PlayerAttackDamage;
       EarthDamage = GameObject.Find("Player").GetComponent<PlayerCombat>().PlayerEarthDamage;
       FireDamage = GameObject.Find("Player").GetComponent<PlayerCombat>().PlayerFireDamage;
       WaterDamage = GameObject.Find("Player").GetComponent<PlayerCombat>().PlayerWaterDamage;
       LightningDamage = GameObject.Find("Player").GetComponent<PlayerCombat>().PlayerLightningDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision) // Player to Enemy Damage from collider on attack animation 
    {
        if (collision.CompareTag("PlayerWeaponCollider"))
        {
            Enemy.GetComponent<EnemyHealth>().TakeDamage(PlayerDamage - Enemy.GetComponent<EnemyHealth>().Armor); // Deals Damage to Enemy after Player's weapon collides with Enemy
            ShowDamage((PlayerDamage - Enemy.GetComponent<EnemyHealth>().Armor).ToString());
        }
        if (collision.CompareTag("PlayerEarthSpellCollider")) // Player to Enemy Earth Spell Damage from collider on prefab asset
        {
            Enemy.GetComponent<EnemyHealth>().TakeDamage(EarthDamage - Enemy.GetComponent<EnemyHealth>().EarthResistance); // Deals Damage to Enemy after Player's earth spell collides with Enemy
            ShowEarthDamage((EarthDamage - Enemy.GetComponent<EnemyHealth>().EarthResistance).ToString());
        }
        if (collision.CompareTag("PlayerFireSpellCollider")) // Player to Enemy Fire Spell Damage from collider on prefab asset
        {
            Enemy.GetComponent<EnemyHealth>().TakeDamage(FireDamage - Enemy.GetComponent<EnemyHealth>().FireResistance); // Deals Damage to Enemy after Player's fire spell collides with Enemy
            ShowFireDamage((FireDamage - Enemy.GetComponent<EnemyHealth>().FireResistance).ToString());
        }
        if (collision.CompareTag("PlayerWaterSpellCollider")) // Player to Enemy Water Spell Damage from collider on prefab asset
        {
            Enemy.GetComponent<EnemyHealth>().TakeDamage(WaterDamage - Enemy.GetComponent<EnemyHealth>().WaterResistance); // Deals Damage to Enemy after Player's water spell collides with Enemy
            ShowWaterDamage((WaterDamage - Enemy.GetComponent<EnemyHealth>().WaterResistance).ToString());
        }
        if (collision.CompareTag("PlayerLightningSpellCollider")) // Player to Enemy Lightning Spell Damage from collider on prefab asset
        {
            Enemy.GetComponent<EnemyHealth>().TakeDamage(LightningDamage - Enemy.GetComponent<EnemyHealth>().LightningResistance); // Deals Damage to Enemy after Player's lightning spell collides with Enemy
            ShowLightningDamage((LightningDamage - Enemy.GetComponent<EnemyHealth>().LightningResistance).ToString());
        }
    }
    
    void ShowDamage(string text)
    {
        if (FloatingText)
        {
            GameObject prefab = Instantiate(FloatingText, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
            prefab.transform.position = Enemy.transform.position + new Vector3(0,1,0);
        }
    }
    void ShowEarthDamage(string text)
    {
        if (FloatingEarthText)
        {
            GameObject prefab = Instantiate(FloatingEarthText, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
            prefab.transform.position = Enemy.transform.position + new Vector3(0, 1, 0);
        }
    }
    void ShowFireDamage(string text)
    {
        if (FloatingFireText)
        {
            GameObject prefab = Instantiate(FloatingFireText, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
            prefab.transform.position = Enemy.transform.position + new Vector3(0, 1, 0);
        }
    }
    void ShowWaterDamage(string text)
    {
        if (FloatingWaterText)
        {
            GameObject prefab = Instantiate(FloatingWaterText, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
            prefab.transform.position = Enemy.transform.position + new Vector3(0, 1, 0);
        }
    }
    void ShowLightningDamage(string text)
    {
        if (FloatingLightningText)
        {
            GameObject prefab = Instantiate(FloatingLightningText, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
            prefab.transform.position = Enemy.transform.position + new Vector3(0, 1, 0);
        }
    }
}
