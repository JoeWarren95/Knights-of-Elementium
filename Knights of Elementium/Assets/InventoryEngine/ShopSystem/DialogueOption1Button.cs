using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOption1Button : MonoBehaviour
{
    public GameObject Player;
    public Text ShopkeeperDialogue;


    public void OnClickEvent()
    {
        {
            ShopkeeperDialogue.text = "Th'ero nok val akun";
        }
    }
}