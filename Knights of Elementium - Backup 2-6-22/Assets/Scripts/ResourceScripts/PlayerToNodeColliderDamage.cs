using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToNodeColliderDamage : MonoBehaviour
{
    public GameObject Node;
    public BoxCollider2D collider;
    public Animator animator;
    //public GameObject ItemDrop; (guarunteed drops)
    public GameObject[] DropTable;
    public int randomDrop;
    public GameObject SilverCoin;
    public GameObject GoldCoin;
    public GameObject CopperCoin;

    void Start()
    {
        animator.SetBool("Destroyed", false);
        randomDrop = Random.Range(0, 22);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerWeaponCollider"))
        {
            BreakObject();
        }
        if (collision.CompareTag("PlayerEarthSpellCollider"))
        {
            BreakObject();
        }
        if (collision.CompareTag("PlayerFireSpellCollider"))
        {
            BreakObject();
        }
        if (collision.CompareTag("PlayerWaterSpellCollider"))
        {
            BreakObject();
        }
        if (collision.CompareTag("PlayerLightningSpellCollider"))
        {
            BreakObject();
        }
    }
    
    public void BreakObject()
    {
            animator.SetBool("Destroyed", true);
    }

    public void RemoveFromGame()
    {
        //Instantiate(ItemDrop, Node.transform.position + new Vector3(0, 0, -1), Node.transform.rotation); (guarunteed drops)
        Instantiate(DropTable[randomDrop], Node.transform.position + new Vector3(0, 0, -1), Node.transform.rotation);
        Instantiate(CopperCoin, Node.transform.position + new Vector3(0.09f, 0.3f, -1), Node.transform.rotation);
        Instantiate(CopperCoin, Node.transform.position + new Vector3(0.08f, 0.3f, -1), Node.transform.rotation);
        Instantiate(CopperCoin, Node.transform.position + new Vector3(0.07f, 0.3f, -1), Node.transform.rotation);
        Instantiate(CopperCoin, Node.transform.position + new Vector3(0.06f, 0.3f, -1), Node.transform.rotation);
        Instantiate(SilverCoin, Node.transform.position + new Vector3(0, 0.1f, -1), Node.transform.rotation);
        Instantiate(SilverCoin, Node.transform.position + new Vector3(0.05f, 0.05f, -1), Node.transform.rotation);
        //Instantiate(GoldCoin, Node.transform.position + new Vector3(0.07f, 0.05f, -1), Node.transform.rotation);
        Destroy(gameObject);
    }
}
