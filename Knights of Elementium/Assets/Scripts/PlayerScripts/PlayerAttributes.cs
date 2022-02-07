using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public int Price;  // must incorporate //
    public int Strength; // increases the player's attack damage!
    public int Weight; // Increases gravity & reduces stagger time!
    public int Armor; // reduces attack damage taken!
    public int EarthResistance; // reduces earth damage taken!
    public int FireResistance; // reduces fire damage taken!
    public int WaterResistance; // reduces water damage taken!
    public int LightningResistance; // reduces lightning damage taken!
    public int EarthPower; // Increases earth spell damage!
    public int FirePower; // Increases fire spell damage!
    public int WaterPower; // Increases water spell damage!
    public int LightningPower; // Increases lightning spell damage!
    public int StaminaTax; // Reduces action stamina cost!
    public int ManaTax; // Reduces spell mana cost!
    public int Vigor; // Increases max health!
    public int Stamina; // Increases max stamina!
    public int Endurance; // Increases stamina regen!
    public int Agility; // must incorporate //
    public int Brilliance; // Increases mana regen!
    public int Vitality; // Increases health regen!
    public int Mana; // Increases max mana!

    public GameObject EquipSystem;


    void Update()
    {
        //Power = EquipSystem.GetComponent<EquipManager>().Power;
        Price = EquipSystem.GetComponent<EquipManager>().Price;
        Strength = EquipSystem.GetComponent<EquipManager>().Strength;
        Weight = EquipSystem.GetComponent<EquipManager>().Weight;
        Armor = EquipSystem.GetComponent<EquipManager>().Armor;
        EarthResistance = EquipSystem.GetComponent<EquipManager>().EarthResistance;
        FireResistance = EquipSystem.GetComponent<EquipManager>().FireResistance;
        WaterResistance = EquipSystem.GetComponent<EquipManager>().WaterResistance;
        LightningResistance = EquipSystem.GetComponent<EquipManager>().LightningResistance;
        EarthPower = EquipSystem.GetComponent<EquipManager>().EarthPower;
        FirePower = EquipSystem.GetComponent<EquipManager>().FirePower;
        WaterPower = EquipSystem.GetComponent<EquipManager>().WaterPower;
        LightningPower = EquipSystem.GetComponent<EquipManager>().LightningPower;
        StaminaTax = EquipSystem.GetComponent<EquipManager>().StaminaTax;
        ManaTax = EquipSystem.GetComponent<EquipManager>().ManaTax;
        Vigor = EquipSystem.GetComponent<EquipManager>().Vigor;
        Stamina = EquipSystem.GetComponent<EquipManager>().Stamina;
        Endurance = EquipSystem.GetComponent<EquipManager>().Endurance;
        Agility = EquipSystem.GetComponent<EquipManager>().Agility;
        Brilliance = EquipSystem.GetComponent<EquipManager>().Brilliance;
        Vitality = EquipSystem.GetComponent<EquipManager>().Vitality;
        Mana = EquipSystem.GetComponent<EquipManager>().Mana;
    }
}
