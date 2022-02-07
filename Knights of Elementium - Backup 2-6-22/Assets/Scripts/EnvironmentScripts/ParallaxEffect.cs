using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour {
  
    private float length, height, startposx, startposy;
    public GameObject cam;
    public float ParallaxHorizontal;
    public float ParallaxVertical;

    void Start() {
        startposx = transform.position.x;
        startposy = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void FixedUpdate()
    {
     float Horizontaldist = (cam.transform.position.x * ParallaxHorizontal);
     float Verticaldist = (cam.transform.position.y * ParallaxVertical);
     

     transform.position = new Vector3(startposx + Horizontaldist, transform.position.y, transform.position.z);
     transform.position = new Vector3(transform.position.x, startposy + Verticaldist, transform.position.z);
    }
}
