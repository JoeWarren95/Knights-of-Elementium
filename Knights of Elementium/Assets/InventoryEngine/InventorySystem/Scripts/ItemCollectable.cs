using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectable : MonoBehaviour
{
    public int ItemID;
    public GameObject PlayerTag;

    private InventoryManager manager;
    
    public bool JustCollected;
    public float CollectionCooldown = 1;

    void Awake() {
        manager = GameObject.Find("InventorySystem").GetComponent<InventoryManager>();
    }

    //add item to inventory or Equip panel when we collect the prefab with this script
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && JustCollected == false)
        {
            ItemCollector collector = other.transform.GetComponent<ItemCollector>();
            if (collector != null)
            {
                JustCollected = true;
                List<string> types = new List<string>(new string[] { "Inventory", "Equip" });
                Debug.Log("cs 25, <ItemCollectable> Picking up Item!");
                manager.AddNewItem(ItemID, types: types);
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        if (JustCollected == true)
        {
            CollectionCooldown -= 10 * Time.deltaTime;
        }
        if (CollectionCooldown <= 0)
        {
            JustCollected = false;
            CollectionCooldown = 1;
        }
    }
}
