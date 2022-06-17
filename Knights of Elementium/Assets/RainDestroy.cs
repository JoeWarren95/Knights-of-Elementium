using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDestroy : MonoBehaviour
{
    private float secondsToDestroy = 1.75f;

    void Start()
    {
        Destroy(gameObject, secondsToDestroy);
    }
}

