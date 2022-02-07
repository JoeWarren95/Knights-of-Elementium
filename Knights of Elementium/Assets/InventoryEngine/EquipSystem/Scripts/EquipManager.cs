using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipManager : MonoBehaviour
{
    public int SlotsAmount;

    //Player stats
    public int Price = 0;
    public int Strength = 0;    
    public int Weight = 0;
    public int Armor = 0;
    public int EarthResistance = 0;
    public int FireResistance = 0;
    public int WaterResistance = 0;
    public int LightningResistance = 0;
    public int EarthPower = 0;
    public int FirePower = 0;
    public int WaterPower = 0;
    public int LightningPower = 0;
    public int StaminaTax = 0;
    public int ManaTax = 0;
    public int Vigor = 0;
    public int Stamina = 0;
    public int Endurance = 0;
    public int Agility = 0;
    public int Brilliance = 0;
    public int Vitality = 0;
    public int Mana = 0;


    //GameObject initiated by scripts
    public GameObject EquipSlots;
    public GameObject EquipInfo;

    InventoryManager manager;

    void Awake () {
        manager = GameObject.Find("InventorySystem").GetComponent<InventoryManager>(); 
        if(manager != null) {
            manager.Equip = gameObject;
        }
        else Debug.LogError("[EquipSystem Error]: Can't find InventorySystem");
    }

    void Update () {
        CheckStats();
        SetEquipInfo();
    }

    //Set text in EquipInfo panel
    void SetEquipInfo() {
        string text = "\n<color=#FF5C34><b>Strength: " + "<color=#FFFFFF>" + Strength + "</color>" + "</b></color>"
        + "\n<color=#FF5C34><b>Weight: " + "<color=#FFFFFF>" + Weight + "</color>" + "</b></color>"
        + "\n<color=#FF5C34><b>Armor: " + "<color=#FFFFFF>" + Armor + "</color>" + "</b></color>"
        + "\n<color=#FF5C34><b>StaminaTax: " + "<color=#FFFFFF>" + StaminaTax + "</color>" + "</b></color>"
        + "\n<color=#FF5C34><b>ManaTax: " + "<color=#FFFFFF>" + ManaTax + "</color>" + "</b></color>"
        + "\n<color=#FF5C34><b>Vigor: " + "<color=#FFFFFF>" + Vigor + "</color>" + "</b></color>"
        + "\n<color=#FF5C34><b>Stamina: " + "<color=#FFFFFF>" + Stamina + "</color>" + "</b></color>"
        + "\n<color=#FF5C34><b>Endurance: " + "<color=#FFFFFF>" + Endurance + "</color>" + "</b></color>"
        + "\n<color=#FF5C34><b>Agility: " + "<color=#FFFFFF>" + Agility + "</color>" + "</b></color>"
        + "\n<color=#FF5C34><b>Brilliance: " + "<color=#FFFFFF>" + Brilliance + "</color>" + "</b></color>"
        + "\n<color=#FF5C34><b>Vitality: " + "<color=#FFFFFF>" + Vitality + "</color>" + "</b></color>"
        + "\n<color=#FF5C34><b>Mana: " + "<color=#FFFFFF>" + Mana + "</color>" + "</b></color>"
        + "\n<color=#34FF67><b>EarthResistance: " + "<color=#FFFFFF>" + EarthResistance + "</color>" + "</b></color>"
        + "\n<color=#34FF67><b>EarthPower: " + "<color=#FFFFFF>" + EarthPower + "</color>" + "</b></color>"
        + "\n<color=#FF3434><b>FirePower: " + "<color=#FFFFFF>" + FirePower + "</color>" + "</b></color>"
        + "\n<color=#FF3434><b>FireResistance: " + "<color=#FFFFFF>" + FireResistance + "</color>" + "</b></color>"
        + "\n<color=#3B34FF><b>WaterPower: " + "<color=#FFFFFF>" + WaterPower + "</color>" + "</b></color>"
        + "\n<color=#3B34FF><b>WaterResistance: " + "<color=#FFFFFF>" + WaterResistance + "</color>" + "</b></color>"
        + "\n<color=#F1FF34><b>LightningPower: " + "<color=#FFFFFF>" + LightningPower + "</color>" + "</b></color>"
        + "\n<color=#F1FF34><b>LightningResistance: " + "<color=#FFFFFF>" + LightningResistance + "</color>" + "</b></color>";

        EquipInfo.transform.Find("Text").GetComponent<Text>().text = text;
    }

    //Checking Equip slots and read info from items to update stats
    void CheckStats() {
        Price = 0;
        Strength = 0;
        Weight = 0;
        Armor = 0;
        EarthResistance = 0;
        FireResistance = 0;
        WaterResistance = 0;
        LightningResistance = 0;
        EarthPower = 0;
        FirePower = 0;
        WaterPower = 0;
        LightningPower = 0;
        StaminaTax = 0;
        ManaTax = 0;
        Vigor = 0;
        Stamina = 0;
        Endurance = 0;
        Agility = 0;
        Brilliance = 0;
        Vitality = 0;
        Mana = 0;
        
        foreach (var slot in manager.SlotList)
        {
            SlotData slotData = slot.GetComponent<SlotData>();
            if(slotData.Type == "Equip" && slotData.HasItem()){
                for(int i=0; i < slotData.GetItemData().amount; i++) {
                    Price += slotData.GetItemData().item.Price;
                    Strength += slotData.GetItemData().item.Strength;
                    Weight += slotData.GetItemData().item.Weight;
                    Armor += slotData.GetItemData().item.Armor;
                    EarthResistance += slotData.GetItemData().item.EarthResistance;
                    FireResistance += slotData.GetItemData().item.FireResistance;
                    WaterResistance += slotData.GetItemData().item.WaterResistance;
                    LightningResistance += slotData.GetItemData().item.LightningResistance;
                    EarthPower += slotData.GetItemData().item.EarthPower;
                    FirePower += slotData.GetItemData().item.FirePower;
                    WaterPower += slotData.GetItemData().item.WaterPower;
                    LightningPower += slotData.GetItemData().item.LightningPower;
                    StaminaTax += slotData.GetItemData().item.StaminaTax;
                    ManaTax += slotData.GetItemData().item.ManaTax;
                    Vigor += slotData.GetItemData().item.Vigor;
                    Stamina += slotData.GetItemData().item.Stamina;
                    Endurance += slotData.GetItemData().item.Endurance;
                    Agility += slotData.GetItemData().item.Agility;
                    Brilliance += slotData.GetItemData().item.Brilliance;
                    Vitality += slotData.GetItemData().item.Vitality;
                    Mana += slotData.GetItemData().item.Mana;
                }
            }
        }
    }
}
