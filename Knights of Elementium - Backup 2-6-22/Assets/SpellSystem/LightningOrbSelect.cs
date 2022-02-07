using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightningOrbSelect : MonoBehaviour
{
    public GameObject Player;

    public void OnClickEvent()
    {
        if (Player.GetComponent<SpellCast>().Lightningball == false)
        {
            Debug.Log("Shifted to Lightning!");
            Player.GetComponent<SpellCast>().Fireball = false;
            Player.GetComponent<SpellCast>().Earthball = false;
            Player.GetComponent<SpellCast>().Waterball = false;
            Player.GetComponent<SpellCast>().Lightningball = true;
        }
    }
}