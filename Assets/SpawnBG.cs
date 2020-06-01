using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBG : MonoBehaviour
{
    public GameObject fire;
    public GameObject items;
    float timeElapsed = 0;
    public float ItemCycle = 3f;
    bool ItemPowerup = true;
    void Update () {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > ItemCycle)
        {
            GameObject temp;
            if(ItemPowerup)
            {
                temp = (GameObject)Instantiate(items);
                Vector3 pos = temp.transform.position;
                temp.transform.position = new Vector3(pos.x, Random.Range(-3, 1), pos.z);
            }
            else
            {
                temp = (GameObject)Instantiate(fire);
                Vector3 pos = temp.transform.position;
                temp.transform.position = new Vector3(pos.x, Random.Range(-3, 1), pos.z);
            }
            timeElapsed -= ItemCycle;
            ItemPowerup = !ItemPowerup;
        }
    }
}
