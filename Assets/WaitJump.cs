using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitJump : MonoBehaviour
{
    public string objectName;
    public Wave wave;

    void Start(){
        objectName = gameObject.name;
    }
    void OnTriggerEnter2D (Collider2D col)
     {
         if (col.gameObject.tag == "ground") 
         {
             //wave.isJumpingA = false;
            if(objectName == "F"){
                wave.isJumpingF = false;
            }
            if(objectName == "D"){
                wave.isJumpingD = false;
            }
            if(objectName == "S"){
                wave.isJumpingS = false;
            }
            if(objectName == "A"){
                wave.isJumpingA = false;
            }
         }

        if (col.gameObject.tag == "item")
        {
            wave.getItem();
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Enemy")
        {
            wave.isGameOver = true;
        }
    }

    void OnMouseOver()
    {
        wave.Jump(this.gameObject);
    }
}
