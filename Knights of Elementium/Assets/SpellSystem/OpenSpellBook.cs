using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSpellBook : MonoBehaviour
{
    public GameObject Player;
    public bool OpenBook;
    public bool EarthSpellKnown;
    public bool FireSpellKnown;
    public bool WaterSpellKnown;
    public bool LightningSpellKnown;
    public GameObject SpellBook;
    public GameObject EarthSpellButton;
    public GameObject FireSpellButton;
    public GameObject WaterSpellButton;
    public GameObject LightningSpellButton;

    void Start()
    {
        OpenBook = false;
        EarthSpellKnown = true;
        FireSpellKnown = true;
        WaterSpellKnown = true;
        LightningSpellKnown = true;
    }

    public void OnClickEvent()
    {
        if (OpenBook == false)
        {
            Debug.Log("Opening Spellboook!");
            OpenBook = true;
            SpellBook.SetActive(true);
            if (EarthSpellKnown == true)
            {
                EarthSpellButton.SetActive(true);
            }
            if (FireSpellKnown == true)
            {
                FireSpellButton.SetActive(true);
            }
            if (WaterSpellKnown == true)
            {
                WaterSpellButton.SetActive(true);
            }
            if (LightningSpellKnown == true)
            {
                LightningSpellButton.SetActive(true);
            }
            if (EarthSpellKnown == false)
            {
                EarthSpellButton.SetActive(false);
            }
            if (FireSpellKnown == false)
            {
                FireSpellButton.SetActive(false);
            }
            if (WaterSpellKnown == false)
            {
                WaterSpellButton.SetActive(false);
            }
            if (LightningSpellKnown == false)
            {
                LightningSpellButton.SetActive(false);
            }
        }
        else if (OpenBook == true)
        {
            Debug.Log("Opening Spellboook!");
            OpenBook = false;
            SpellBook.SetActive(false);
        }
    }

    void Update()
    {

    }
}