using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireOrbSelect : MonoBehaviour
{
    public GameObject Player;

    public void OnClickEvent()
    {
        if (Player.GetComponent<SpellCast>().Fireball == false)
        {
            Debug.Log("Shifted to Fire!");
            Player.GetComponent<SpellCast>().Fireball = true;
            Player.GetComponent<SpellCast>().Earthball = false;
            Player.GetComponent<SpellCast>().Waterball = false;
            Player.GetComponent<SpellCast>().Lightningball = false;
        }
    }
}