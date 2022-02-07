using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCast : MonoBehaviour
{
    public Transform CastPoint;
    public GameObject FireBall;
    public GameObject WaterBall;
    public GameObject EarthBall;
    public GameObject LightningBall;
    public GameObject Player;
    public bool Fireball;
    public bool Earthball;
    public bool Waterball;
    public bool Lightningball;

    void Start()
    {
        Fireball = true;
        Waterball = false;
        Earthball = false;
        Lightningball = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && Player.GetComponent<PlayerHealth>().currentMana >= 20 && Player.GetComponent<PlayerMovement>().Staggered == false && Fireball == true)
        {
            Instantiate(FireBall, CastPoint.position, CastPoint.rotation);
            Player.GetComponent<PlayerHealth>().TaxMana();
        }
        if (Input.GetKeyDown(KeyCode.Z) && Player.GetComponent<PlayerHealth>().currentMana >= 20 && Player.GetComponent<PlayerMovement>().Staggered == false && Waterball == true)
        {
            Instantiate(WaterBall, CastPoint.position, CastPoint.rotation);
            Player.GetComponent<PlayerHealth>().TaxMana();
        }
        if (Input.GetKeyDown(KeyCode.Z) && Player.GetComponent<PlayerHealth>().currentMana >= 20 && Player.GetComponent<PlayerMovement>().Staggered == false && Earthball == true)
        {
            Instantiate(EarthBall, CastPoint.position, CastPoint.rotation);
            Player.GetComponent<PlayerHealth>().TaxMana();
        }
        if (Input.GetKeyDown(KeyCode.Z) && Player.GetComponent<PlayerHealth>().currentMana >= 20 && Player.GetComponent<PlayerMovement>().Staggered == false && Lightningball == true)
        {
            Instantiate(LightningBall, CastPoint.position, CastPoint.rotation);
            Player.GetComponent<PlayerHealth>().TaxMana();
        }
    }
}
