using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserHit : MonoBehaviour
{
    public GameObject FloatingEarthText;
    public GameObject Player;
    public GameObject Enemy;
    public int EarthPower;
    public int FirePower;
    public int WaterPower;
    public int LightningPower;

    void Update()
    {
        EarthPower = Enemy.GetComponent<KnightHealth>().EarthPower;
        FirePower = Enemy.GetComponent<KnightHealth>().FirePower;
        WaterPower = Enemy.GetComponent<KnightHealth>().WaterPower;
        LightningPower = Enemy.GetComponent<KnightHealth>().LightningPower;
    }
    void Start()
    {
        Player = GameObject.Find("Player");
        Enemy = GameObject.Find("RootKnight");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Player.GetComponent<DashMove>().IsDashing == false && Player.GetComponent<PlayerHealth>().CanBeDamaged == true)
        {
            Player.GetComponent<PlayerHealth>().TakeDamage(EarthPower - Player.GetComponent<PlayerAttributes>().EarthResistance);           // Player takes enemy earth spell damage - resistance
            ShowEarthDamage((EarthPower - Player.GetComponent<PlayerAttributes>().EarthResistance).ToString());                             // show earth dmg done to player
            Player.GetComponent<PlayerMovement>().Staggered = true;                                                                         // Stagger Player
            Player.GetComponent<PlayerMovement>().StaggerTime = 0.05f * EarthPower - Player.GetComponent<PlayerAttributes>().Weight;        // lower duration of stagger by player weight
        }
    }
    
    void ShowEarthDamage(string text)
    {
        if (FloatingEarthText)
        {
            GameObject prefab = Instantiate(FloatingEarthText, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
            prefab.transform.position = Player.transform.position + new Vector3(0, 1, 0);
        }
    }
}
