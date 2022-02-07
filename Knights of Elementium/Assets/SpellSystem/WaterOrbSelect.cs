using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterOrbSelect : MonoBehaviour
{
    public GameObject Player;

    public void OnClickEvent()
    {
        if (Player.GetComponent<SpellCast>().Waterball == false)
        {
            Debug.Log("Shifted to Water!");
            Player.GetComponent<SpellCast>().Fireball = false;
            Player.GetComponent<SpellCast>().Earthball = false;
            Player.GetComponent<SpellCast>().Waterball = true;
            Player.GetComponent<SpellCast>().Lightningball = false;
        }
    }
}