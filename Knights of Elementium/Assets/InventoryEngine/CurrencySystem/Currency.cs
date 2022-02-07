using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public Text CurrencyText;
    public int CurrencyQuantity;
    private int Wealth;

    void Start()
    {
        //PlayerPrefs.SetInt("Money", 0); // Reset cache to 0
        CurrencyQuantity = PlayerPrefs.GetInt("Money"); // Load Wealth Value

    }

    void Update()
    {
        CurrencyText.text = CurrencyQuantity.ToString(); // Interface Text
        CurrencyQuantity = PlayerPrefs.GetInt("Money"); // Load Wealth Value
        if (CurrencyQuantity <= 0)
        {
            CurrencyQuantity = 0;
        }
    }
   
    public void IncreaseQuantityCopper()
    {
        CurrencyQuantity += 1;
        PlayerPrefs.SetInt("Money", CurrencyQuantity); // Save Wealth Value
    }
    public void IncreaseQuantitySilver()
    {
        CurrencyQuantity += 5;
        PlayerPrefs.SetInt("Money", CurrencyQuantity); // Save Wealth Value
    }
    public void IncreaseQuantityGold()
    {
        CurrencyQuantity += 25;
        PlayerPrefs.SetInt("Money", CurrencyQuantity); // Save Wealth Value
    }
    
    public void DeathPenalty()
    {
        CurrencyQuantity -= 15;
        PlayerPrefs.SetInt("Money", CurrencyQuantity); // Save Wealth Value
    }
}
