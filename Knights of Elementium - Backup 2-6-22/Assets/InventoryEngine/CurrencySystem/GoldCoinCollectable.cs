using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinCollectable : MonoBehaviour
{
    public GameObject PlayerTag; 
    public bool JustCollected;
    public float CollectionCooldown = 1;
    public GameObject CurrencyCounter;

    //add currency quantity to Currency script

    void Start()
    {
        CurrencyCounter = GameObject.Find("CurrencySystem");
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && JustCollected == false)
        {
                JustCollected = true;
                Debug.Log("Picking up Currency!");
                gameObject.SetActive(false);
                Destroy(gameObject);
                CurrencyCounter.GetComponent<Currency>().IncreaseQuantityGold();
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
