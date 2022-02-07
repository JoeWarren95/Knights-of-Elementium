using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheckKnights : MonoBehaviour {

    private Knight_Behavior enemyParent;
    public bool inRange;
    private Animator anim;
    public bool EnemyIsAlive = true;
    public GameObject HotZone;

    public void EnemyDeath()
    {
        EnemyIsAlive = false;
    }

    public void EnemyRevival()
    {
        EnemyIsAlive = true;
    }

    private void Awake()
    {
        enemyParent = GetComponentInParent<Knight_Behavior>();
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("RootKnight_Attack1"))
        {
            enemyParent.Flip();
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    public void Reset()
    {
            inRange = false;
            gameObject.SetActive(false);
            enemyParent.triggerArea.SetActive(true);
            enemyParent.inRange = false;
            enemyParent.SelectTarget();
            enemyParent.ForceStopAttack();
    }

    private void OnTriggerExit2D(Collider2D collider) // Player Exits Hot Zone to Activate Enemy Trigger Area if Enemy is alive
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (EnemyIsAlive == true)
            {
                inRange = false;
                gameObject.SetActive(false);
                enemyParent.triggerArea.SetActive(true);
                enemyParent.inRange = false;
                enemyParent.SelectTarget();
                enemyParent.ForceStopAttack();
            }
        }
        else if (EnemyIsAlive == false)
        {
            this.enabled = false;      // deactivates this script
            HotZone.SetActive(false); // deactivates Enemy Hotzone
        }
    }
}
