using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public void StartGame()
    {
        GameObject player = GameObject.Find("Player");
        //player.transform.position = new Vector3(-41f, 52f, -176f);
    }
}
