using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarthOrbSelect : MonoBehaviour
{
    public GameObject Player;

    public void OnClickEvent()
    {
        if (Player.GetComponent<SpellCast>().Earthball == false)
        {
            Debug.Log("Shifted to Earth!");
            Player.GetComponent<SpellCast>().Fireball = false;
            Player.GetComponent<SpellCast>().Earthball = true;
            Player.GetComponent<SpellCast>().Waterball = false;
            Player.GetComponent<SpellCast>().Lightningball = false;
        }
    }
}