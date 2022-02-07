using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemTip : MonoBehaviour
{
    InventoryManager manager;

    void Awake()
    {
        manager = GameObject.Find("InventorySystem").GetComponent<InventoryManager>(); 
        if(manager != null) manager.TipPanel = gameObject;
        else Debug.LogError("[InventorySystem Error]: Can't find InventorySystem");
    }

    // Start is called before the first frame update
    void Start()
    {
        Deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf){
            gameObject.transform.position = Input.mousePosition;
        }
    }

    //activate tip
    public void Activate(Item item)
    {
        // Tooltip displayed when no stats equal zero
        if (item.Strength != 0 && item.Weight != 0 && item.Armor != 0 && item.StaminaTax != 0 && item.ManaTax != 0 && item.Vigor != 0 && item.Stamina != 0 && item.Endurance != 0 && item.Agility != 0 && item.Brilliance != 0 && item.Vitality != 0)
        {
            if (item.Mana != 0 && item.EarthPower != 0 && item.EarthResistance != 0 && item.FirePower != 0 && item.FireResistance != 0 && item.WaterPower != 0 && item.WaterResistance != 0 && item.LightningPower != 0 && item.LightningResistance != 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Strength: " + item.Strength.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Weight: " + item.Weight.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Armor: " + item.Armor.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "StaminaTax: " + item.StaminaTax.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "ManaTax: " + item.ManaTax.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Vigor: " + item.Vigor.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Stamina: " + item.Stamina.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Endurance: " + item.Endurance.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Agility: " + item.Agility.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Brilliance: " + item.Brilliance.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Vitality: " + item.Vitality.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Mana: " + item.Mana.ToString() + "</color>"
            + "\n<color=#34FF42>" + "EarthPower: " + item.EarthPower.ToString() + "</color>"
            + "\n<color=#34FF42>" + "EarthResistance: " + item.EarthResistance.ToString() + "</color>"
            + "\n<color=#FF4834>" + "FirePower: " + item.FirePower.ToString() + "</color>"
            + "\n<color=#FF4834>" + "FireResistance: " + item.FireResistance.ToString() + "</color>"
            + "\n<color=#3B34FF>" + "WaterPower: " + item.WaterPower.ToString() + "</color>"
            + "\n<color=#3B34FF>" + "WaterResistance: " + item.WaterResistance.ToString() + "</color>"
            + "\n<color=#DAFF34>" + "LightningPower: " + item.LightningPower.ToString() + "</color>"
            + "\n<color=#DAFF34>" + "LightningResistance: " + item.LightningResistance.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }
        
        // Tooltip displayed when all stats equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }
        
        // Tooltip displayed when all stats but strength equal zero
        if (item.Strength != 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Strength: " + item.Strength.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but weight equal zero
        if (item.Strength == 0 && item.Weight != 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Weight: " + item.Weight.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but armor equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor != 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Armor: " + item.Armor.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but StaminaTax equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax != 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "StaminaTax: " + item.StaminaTax.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but ManaTax equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax != 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "ManaTax: " + item.ManaTax.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but Vigor equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor != 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Vigor: " + item.Vigor.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but Stamina equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina != 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Stamina: " + item.Stamina.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but Endurance equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance != 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Endurance: " + item.Endurance.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but Agility equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility != 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Agility: " + item.Agility.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but Brilliance equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance != 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Brilliance: " + item.Brilliance.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but Vitality equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality != 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Vitality: " + item.Vitality.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but Mana equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana != 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "Mana: " + item.Mana.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but EarthPower equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower != 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "EarthPower: " + item.EarthPower.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but EarthResistance equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance != 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "EarthResistance: " + item.EarthResistance.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but FirePower equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower != 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "FirePower: " + item.FirePower.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but FireResistance equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance != 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "FireResistance: " + item.FireResistance.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but WaterPower equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower != 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "WaterPower: " + item.WaterPower.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but WaterResistance equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance != 0 && item.LightningPower == 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "WaterResistance: " + item.WaterResistance.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but LightningPower equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower != 0 && item.LightningResistance == 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "LightningPower: " + item.WaterResistance.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Tooltip displayed when all stats but LightningResistance equal zero
        if (item.Strength == 0 && item.Weight == 0 && item.Armor == 0 && item.StaminaTax == 0 && item.ManaTax == 0 && item.Vigor == 0 && item.Stamina == 0 && item.Endurance == 0 && item.Agility == 0 && item.Brilliance == 0 && item.Vitality == 0)
        {
            if (item.Mana == 0 && item.EarthPower == 0 && item.EarthResistance == 0 && item.FirePower == 0 && item.FireResistance == 0 && item.WaterPower == 0 && item.WaterResistance == 0 && item.LightningPower == 0 && item.LightningResistance != 0)
            {
                //text in Tip FF5C34
                string data = "<color=#000000><b>" + item.Name + "</b></color>"
            + "\n<color=#FFDD34>" + "Price: " + item.Price.ToString() + "</color>"
            + "\n<color=#FF5C34>" + "LightningPower: " + item.WaterResistance.ToString() + "</color>";

                gameObject.transform.GetChild(0).GetComponent<Text>().text = data;
                gameObject.transform.position = Input.mousePosition;

                gameObject.SetActive(true);
            }
        }

        // Currently, all items with a single stat will display a tooltip. First, I must make these 20 look the way that I want before I grind the long road of multistat items.
    }

    //deactivate tip
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
