using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;
using UnityEditor;

public class InventoryDatabase : MonoBehaviour
{
    public List<Item> items;

    void Awake()
    {
        LoadItemsFromFile();
    }
    
    //Load and parse items from JSON file
    private void LoadItemsFromFile () {
        try {
            items = new List<Item>();

            TextAsset txtAsset = Resources.Load("Items/Items") as TextAsset;
            JsonData itemsData = JsonMapper.ToObject(txtAsset.text);

            if(itemsData != null){
                for (int i = 0; i < itemsData.Count; i++)
                {
                    items.Add(new Item((int)itemsData[i]["id"], itemsData[i]["name"].ToString(), (int)itemsData[i]["price"], (int)itemsData[i]["strength"], (int)itemsData[i]["weight"], (int)itemsData[i]["armor"], (int)itemsData[i]["earthresistance"], (int)itemsData[i]["fireresistance"], (int)itemsData[i]["waterresistance"], (int)itemsData[i]["lightningresistance"], (int)itemsData[i]["earthpower"], (int)itemsData[i]["firepower"], (int)itemsData[i]["waterpower"], (int)itemsData[i]["lightningpower"], (int)itemsData[i]["staminatax"], (int)itemsData[i]["manatax"], (int)itemsData[i]["vigor"], (int)itemsData[i]["stamina"], (int)itemsData[i]["endurance"], (int)itemsData[i]["agility"], (int)itemsData[i]["brilliance"], (int)itemsData[i]["vitality"], (int)itemsData[i]["mana"], (bool)itemsData[i]["stackable"]));
                }
            }else Debug.LogError("[InventorySystem Error]: Can't find items.json");
        }
        catch(DirectoryNotFoundException e) {
            Debug.LogError("[InventorySystem Error]: Please, set the correct path to JSON file with items data, using \"Path To Data File\" variable");
        }
        catch(FileNotFoundException e) {
            Debug.LogError("[InventorySystem Error]: Please, set the correct path to JSON file with items data, using \"Path To Data File\" variable");
        }
        catch(KeyNotFoundException e) {
            Debug.LogError("[InventorySystem Error]: Can't find the key in your JSON database");
        }
    }

    //Get Item by id from JSON database
    public Item FindItemByID (int id) {
        foreach (var item in items) {
            if(item.ID == id) {
                return item;
            }
        }

        Debug.LogWarning("[InventorySystem Warning]: Item with ID = " + id.ToString() + " wasn't found in your JSON database");
        return null;
    }
}

[System.Serializable] 
public class Item
{
    public int ID;
    public string Name;
    public int Price;
    public int Strength;
    public int Weight;
    public int Armor;
    public int EarthResistance;
    public int FireResistance;
    public int WaterResistance;
    public int LightningResistance;
    public int EarthPower;
    public int FirePower;
    public int WaterPower;
    public int LightningPower;
    public int StaminaTax;
    public int ManaTax;
    public int Vigor;
    public int Stamina;
    public int Endurance;
    public int Agility;
    public int Brilliance;
    public int Vitality;
    public int Mana;

    public bool Stackable;
    public Sprite Sprite;
    public GameObject Prefab;

    public Item(int id, string name, int price, int strength, int weight, int armor, int earthresistance, int fireresistance, int waterresistance, int lightningresistance, int earthpower, int firepower, int waterpower, int lightningpower, int staminatax, int manatax, int vigor, int stamina, int endurance, int agility, int brilliance, int vitality, int mana,  bool stackable)
    {
        this.ID = id;
        this.Name = name;
        this.Price = price;
        this.Strength = strength;
        this.Weight = weight;
        this.Armor = armor;
        this.EarthResistance = earthresistance;
        this.FireResistance = fireresistance;
        this.WaterResistance = waterresistance;
        this.LightningResistance = lightningresistance;
        this.EarthPower = earthpower;
        this.FirePower = firepower;
        this.WaterPower = waterpower;
        this.LightningPower = lightningpower;
        this.StaminaTax = staminatax;
        this.ManaTax = manatax;
        this.Vigor = vigor;
        this.Stamina = stamina;
        this.Endurance = endurance;
        this.Agility = agility;
        this.Brilliance = brilliance;
        this.Vitality = vitality;
        this.Mana = mana;
        this.Stackable = stackable;
        this.Sprite = Resources.Load<Sprite>("Items/Sprites/" + id.ToString());
        this.Prefab = Resources.Load<GameObject>("Items/Prefabs/" + id.ToString());
    }

    public Item(int id)
    {
        this.ID = id;
        this.Name = "";
        this.Price = 0;
        this.Strength = 0;
        this.Weight = 0;
        this.Armor = 0;
        this.EarthResistance = 0;
        this.FireResistance = 0;
        this.WaterResistance = 0;
        this.LightningResistance = 0;
        this.EarthPower = 0;
        this.FirePower = 0;
        this.WaterPower = 0;
        this.LightningPower = 0;
        this.StaminaTax = 0;
        this.ManaTax = 0;
        this.Vigor = 0;
        this.Stamina = 0;
        this.Endurance = 0;
        this.Agility = 0;
        this.Brilliance = 0;
        this.Vitality = 0;
        this.Mana = 0;
        this.Stackable = false;
    }

    public Item()
    {
        this.ID = -1;
        this.Name = "";
        this.Price = 0;
        this.Strength = 0;
        this.Weight = 0;
        this.Armor = 0;
        this.EarthResistance = 0;
        this.FireResistance = 0;
        this.WaterResistance = 0;
        this.LightningResistance = 0;
        this.EarthPower = 0;
        this.FirePower = 0;
        this.WaterPower = 0;
        this.LightningPower = 0;
        this.StaminaTax = 0;
        this.ManaTax = 0;
        this.Vigor = 0;
        this.Stamina = 0;
        this.Endurance = 0;
        this.Agility = 0;
        this.Brilliance = 0;
        this.Vitality = 0;
        this.Mana = 0;
        this.Stackable = false;
    }
}
