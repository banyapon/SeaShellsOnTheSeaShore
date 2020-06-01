using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnemy : MonoBehaviour
{
    public float objectSpeed = -0.05f;
    public int dam = 1;

    void Update()
    {
        transform.Translate(objectSpeed, 0, 0);
        if(dam <= 0){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D col)
     {
        if (col.gameObject.tag == "clear") 
        {
            objectSpeed = 0.05f;
            Destroy(this.gameObject,3f);
        }
        if (col.gameObject.tag == "jumper") 
        {
            objectSpeed = 0.05f;
            Destroy(this.gameObject,3f);
        }
     }
}
