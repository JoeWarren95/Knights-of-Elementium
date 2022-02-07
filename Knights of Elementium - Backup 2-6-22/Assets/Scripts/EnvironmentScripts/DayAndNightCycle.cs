using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DayAndNightCycle : MonoBehaviour
{
    public SpriteRenderer sprite; // Sky Background and whatever else I want to change with time
    public SpriteRenderer MiddleRoot1;
    public SpriteRenderer PlayerLightRing;
    public GameObject PlayerVignette;
    public Tilemap DayNightTileGrid;
    public float WorldClock;
    public bool DownTick;
    public bool UpTick;
    public bool Darkness;
    public bool Luminosity;

    void Start()
    {

        sprite = GetComponent<SpriteRenderer>();
        DownTick = true;
        UpTick = false;
        WorldClock = 12;
        PlayerVignette.SetActive(true);
    }

    void Update()
    {
        if (WorldClock >= 0 && WorldClock <= 24) // if it's getting brighter or darker outside
        {
            PlayerVignette.transform.localScale = new Vector2(1.0f + 0.75f * WorldClock, 1.0f + 0.75f * WorldClock);
            DayNightTileGrid.color = new Color(0.20f+ 0.416f * WorldClock, 0.20f + 0.416f * WorldClock, 0.20f + 0.416f * WorldClock, 1);
            MiddleRoot1.color = new Color(0.20f + 0.416f * WorldClock, 0.20f + 0.416f * WorldClock, 0.20f + 0.416f * WorldClock, 1);
            sprite.color = new Color(0.66f - 0.1f * WorldClock, 0.0f + 0.1f * WorldClock, 0.33f + 0.1f * WorldClock, 1);
            PlayerLightRing.color = new Color(1.0f, 1.0f, 1.0f, 1.0f - 0.60f * WorldClock); // Light Ring appears in darkness & disappears in light
        }
        if (DownTick == true && Darkness == false && Luminosity == false) // 9 hours getting darker
        {
            WorldClock -= 0.50f * Time.deltaTime;
        }
        if (DownTick == true && Darkness == true) // 3 hours of Darkening transition
        {
            WorldClock -= 0.05f * Time.deltaTime;
        }
        if (DownTick == true && Luminosity == true) // 3 hours Light <-- Bright
        {
            WorldClock -= 0.05f * Time.deltaTime;
        }
        if (WorldClock <= -18) // Begin Uptick
        {
            DownTick = false;
            UpTick = true;
        }
        if (WorldClock >= 28) // 3 hours of bright day post 24 hour mark
        {
            DownTick = true;
            UpTick = false;
        }
        if (UpTick == true && Luminosity == true) // 3 hours Light --> Bright
        {
            WorldClock += 0.05f * Time.deltaTime;
        }
        if (UpTick == true && Darkness == false) // 9 hours Light --> Dark
        {
            WorldClock += 0.50f * Time.deltaTime;
        }
        if (UpTick == true && Darkness == true) // 3 hours Dark --> Light
        {
            WorldClock += 0.05f * Time.deltaTime;
        }
        if (WorldClock >= 21 && WorldClock <= 24) // Slower Luminosity transition
        {
            Luminosity = true;
        }
        else
        {
            Luminosity = false;
        }
        if (WorldClock <= 4 && WorldClock >= 0) // Slower Darkness transition
        {
            Darkness = true;
        }
        else
        {
            Darkness = false;
        }
    }
}