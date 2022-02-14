using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpawn : MonoBehaviour
{
    private RectTransform rt;
    public bool IsRaining;
    public GameObject RainDropletForeground;

    void Update()
    {
        //if (IsRaining == true)
        {
            rt = GetComponent<RectTransform>();
            //instantiate your dot in the bounds of that recttransform
            for (int i = 0; i < 1; i++)
            {
                Instantiate(RainDropletForeground, new Vector3(Random.Range(rt.rect.xMin, rt.rect.xMax),
                      Random.Range(rt.rect.yMin, rt.rect.yMax), 0) + rt.transform.position, Quaternion.identity);
            }
        }
    }
}
