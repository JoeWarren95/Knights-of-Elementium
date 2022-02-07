using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCollider : MonoBehaviour
{
    public GameObject Player;
    public GameObject DialogueSystem;
    public GameObject DialogueOption1;
    public Text Option1;
    public GameObject DialogueOption2;
    public Text Option2;
    public GameObject ShoppingSystem;
    public bool PlayerInRange;
    public Text ShopkeeperDialogue;

    // Start is called before the first frame update
    void Start()
    {
        //ShoppingSystem.SetActive(false);
        DialogueSystem.SetActive(false);
        DialogueOption1.SetActive(false);
        DialogueOption2.SetActive(false);
        PlayerInRange = false;
        ShopkeeperDialogue.text = "Wanna get fucked?";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = true;
            //ShoppingSystem.SetActive(false);
            DialogueSystem.SetActive(true);
            DialogueOption1.SetActive(true);
            Option1.text = "Fuck off bitch";
            DialogueOption2.SetActive(true);
            Option2.text = "Yes daddy";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = false;
            //ShoppingSystem.SetActive(false);
            DialogueSystem.SetActive(false);
            DialogueOption1.SetActive(false);
            DialogueOption2.SetActive(false);
            ShopkeeperDialogue.text = "Wanna get fucked?";
        }
    }
}
