using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaCheck : MonoBehaviour {

    private Enemy_behavior enemyParent;
    public GameObject Player;
    public Animator animator;

    private void Awake()
    {
        enemyParent = GetComponentInParent<Enemy_behavior>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && enemyParent.GetComponent<EnemyHealth>().IsDead == false)
        {
            gameObject.SetActive(false);
            enemyParent.target = collider.transform;
            enemyParent.inRange = true;
            enemyParent.hotZone.SetActive(true);
            Player.GetComponent<PlayerHealth>().InCombat = true;
            animator.SetBool("canWalk", true); // set true that enemy can walk
        }
    }    
}
