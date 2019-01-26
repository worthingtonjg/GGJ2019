using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    public bool battleStarted;
    public int Escaped;

    void OnTriggerEnter(Collider otherObject)
    {
        if(otherObject.tag == "DropShip")
        {
            GameObject.Destroy(otherObject.transform.gameObject);
            
            if(battleStarted)
            {
                ++Escaped;
            }
        }
    }
}
