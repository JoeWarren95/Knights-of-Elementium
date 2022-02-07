using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenStorageButton : MonoBehaviour
{
    public GameObject Player;
    public bool OpenStorage;
    public GameObject StorageSystem;

    void Start()
    {
        OpenStorage = false;
    }

    public void OnClickEvent()
    {
        if (OpenStorage == false)
        {
            Debug.Log("Opening Storage Chest!");
            OpenStorage = true;
        }
        else if (OpenStorage == true)
        {
            Debug.Log("Closing Storage Chest!");
            OpenStorage = false;
        }
    }

    void Update()
    {
        if (OpenStorage == true)
        {
            StorageSystem.SetActive(true);
        }
        if (OpenStorage == false)
        {
            StorageSystem.SetActive(false);
        }
    }
}