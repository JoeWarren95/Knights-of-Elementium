using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOption2Button : MonoBehaviour
{
    public GameObject Player;
    public Text ShopkeeperDialogue;


    public void OnClickEvent()
    {
        {
            ShopkeeperDialogue.text = "Okay, bend over";
        }
    }
}