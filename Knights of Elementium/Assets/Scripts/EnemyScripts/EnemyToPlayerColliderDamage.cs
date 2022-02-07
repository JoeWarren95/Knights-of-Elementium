using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToPlayerColliderDamage : MonoBehaviour
{
    public GameObject MainPlayer;
    public GameObject ParentEnemy;
    public GameObject FloatingText;
    public int attackDamage; // Base Damage of Enemy from Enemy_behavior
    public int Strength; // Base Stagger Power of Enemy from Enemy_behavior
    public int Weight; // Base Weight of Enemy from Enemy_behavior
    public int EnemyStaggerTime;
    public Rigidbody2D rb;
    public Animator Animator;
   
    void Update()
    {
        Strength = ParentEnemy.GetComponent<EnemyHealth>().Strength;
        Weight = ParentEnemy.GetComponent<EnemyHealth>().Weight;
        EnemyStaggerTime = MainPlayer.GetComponent<PlayerAttributes>().Strength - ParentEnemy.GetComponent<EnemyHealth>().Weight;
        attackDamage = ParentEnemy.GetComponent<Enemy_behavior>().EnemyDamage;
    }
    
    private void OnTriggerEnter2D(Collider2D collision) // Enemy to Player Damage
    {
        if (collision.CompareTag("Player") && MainPlayer.GetComponent<PlayerHealth>().CanBeDamaged == true)
        {
            MainPlayer.GetComponent<PlayerHealth>().TakeDamage(attackDamage - MainPlayer.GetComponent<PlayerAttributes>().Armor);   // Player takes enemy atk dmg
            ShowDamage((attackDamage + Strength - MainPlayer.GetComponent<PlayerAttributes>().Armor).ToString());                   // show dmg done to player
            MainPlayer.GetComponent<PlayerMovement>().Staggered = true;                                                             // Stagger Player
            MainPlayer.GetComponent<PlayerMovement>().StaggerTime = Strength - MainPlayer.GetComponent<PlayerAttributes>().Weight;  // lower duration of stagger by player weight
        }
        if (collision.CompareTag("PlayerWeaponCollider")) // Enemy & Player Parry Interaction (Both get staggered based on strength & weight)
        {
            MainPlayer.GetComponent<PlayerMovement>().Staggered = true;                                                             // Stagger Player
            ParentEnemy.GetComponent<EnemyHealth>().Staggered = true;                                                               // Stagger Enemy
            MainPlayer.GetComponent<PlayerMovement>().StaggerTime = Strength - MainPlayer.GetComponent<PlayerAttributes>().Weight;  // lower duration of player stagger by player weight
            Debug.Log("Parried Enemy Attack!");
            Animator.SetTrigger("Parry");
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
