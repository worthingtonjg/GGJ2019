using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugCamera : MonoBehaviour
{
    GameObject player;
    GameObject debugCam;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Z))
        {
            this.gameObject.SetActive(true);
            player.SetActive(false);
        }
    }
}
