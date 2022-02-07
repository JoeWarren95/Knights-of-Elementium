using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenStatsButton : MonoBehaviour
{
    public GameObject Player;
    public bool OpenStats;
    public GameObject StatsWindow;

    void Start()
    {
        OpenStats = false;
    }

    public void OnClickEvent()
    {
        if (OpenStats == false)
        {
            Debug.Log("Opening Stat Window!");
            OpenStats = true;
        }
        else if (OpenStats == true)
        {
            Debug.Log("Closing Stat Window!");
            OpenStats = false;
        }
    }

    void Update()
    {
        if (OpenStats == true)
        {
            StatsWindow.SetActive(true);
        }
        if (OpenStats == false)
        {
            StatsWindow.SetActive(false);
        }
    }
}