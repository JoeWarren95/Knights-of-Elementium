using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightToPlayerColliderDamage : MonoBehaviour
{
    public GameObject MainPlayer;
    public GameObject ParentEnemy;
    public GameObject FloatingText;
    public int attackDamage; // Base Damage of Enemy from Enemy_behavior
    public int Strength; // Base Stagger Power of Enemy from Enemy_behavior
    public Rigidbody2D rb;
    
    void Update()
    {
        Strength = ParentEnemy.GetComponent<KnightHealth>().Strength;
        attackDamage = ParentEnemy.GetComponent<Knight_Behavior>().EnemyDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision) // Enemy to Player Damage
    {
        if (collision.CompareTag("Player") && MainPlayer.GetComponent<PlayerHealth>().CanBeDamaged == true)
        {
            MainPlayer.GetComponent<PlayerHealth>().TakeDamage(attackDamage - MainPlayer.GetComponent<PlayerAttributes>().Armor);
            ShowDamage((attackDamage + Strength - MainPlayer.GetComponent<PlayerAttributes>().Armor).ToString());
            MainPlayer.GetComponent<PlayerMovement>().Staggered = true;
            MainPlayer.GetComponent<PlayerMovement>().StaggerTime = Strength - MainPlayer.GetComponent<PlayerAttributes>().Weight;
        }
    }
    void ShowDamage(string text)
    {
        if (FloatingText)
        {
            GameObject prefab = Instantiate(FloatingText, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
            prefab.transform.position = MainPlayer.transform.position + new Vector3(0,1,0);
        }
    }
}
