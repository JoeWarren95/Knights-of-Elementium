using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoolCollider : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public GameObject HotZone;
    public GameObject SpellBookSystem;
    public GameObject SpellBook;
    public GameObject SpellBookOpenButton;
    public GameObject StorageOpenButton;
    public GameObject InventoryOpenButton;
    public GameObject InventorySystem;
    public GameObject Crafting;
    public GameObject StoreSlotPlace;
    public GameObject CraftSlotPlace;
    public GameObject CraftInfo;
    public bool PlayerInRange;

    // Start is called before the first frame update
    void Start()
    {
        SpellBookSystem.SetActive(false);
        SpellBook.SetActive(false);
        Crafting.SetActive(false);
        CraftSlotPlace.SetActive(false);
        CraftInfo.SetActive(false);
        StoreSlotPlace.SetActive(false);
        StorageOpenButton.SetActive(false);
        SpellBookOpenButton.GetComponent<OpenSpellBook>().OpenBook = false;
        StorageOpenButton.GetComponent<OpenStorageButton>().OpenStorage = false;
        InventoryOpenButton.GetComponent<InventoryOpenButton>().InventoryOpen = false;
    }


private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = true;
            transform.GetChild(0).gameObject.SetActive(true);
            SpellBookSystem.SetActive(true);
            Crafting.SetActive(true);
            StorageOpenButton.SetActive(true);
            StoreSlotPlace.SetActive(true);
            InventoryOpenButton.GetComponent<InventoryOpenButton>().InventoryOpen = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = false;
            transform.GetChild(0).gameObject.SetActive(false);
            SpellBookSystem.SetActive(false);
            SpellBook.SetActive(false);
            StorageOpenButton.SetActive(false);
            StoreSlotPlace.SetActive(false);
            Crafting.SetActive(false);
            CraftInfo.SetActive(false);
            CraftSlotPlace.SetActive(false);
            SpellBookOpenButton.GetComponent<OpenSpellBook>().OpenBook = false;
            StorageOpenButton.GetComponent<OpenStorageButton>().OpenStorage = false;
            InventoryOpenButton.GetComponent<InventoryOpenButton>().InventoryOpen = false;
        }
    }

    void Update ()
    {
        if (PlayerInRange == true)
        {
            if(Input.GetKeyDown(KeyCode.X)) // Call Rest Function
            {
                transform.GetChild(0).gameObject.SetActive(false);
                Player.GetComponent<PlayerHealth>().Rest();
                HotZone.GetComponent<HotZoneCheck>().Reset();
            }
        }
    }
}
