using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public float objectSpeed = -0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(objectSpeed, 0, 0);
    }

    void OnTriggerEnter2D (Collider2D col)
     {
         if (col.gameObject.tag == "clear") 
         {
            Destroy(this.gameObject);
        }
     }
}
