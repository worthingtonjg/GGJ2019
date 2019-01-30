using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public AudioClip music;
    public void Start()
    {
        GameObject player = GameObject.Find("Player");

        if(player != null)
        {
            var audioSource = player.GetComponent<AudioSource>();
            audioSource.clip = music;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            SceneManager.LoadScene("MainScene");
        }

        if(Input.GetKeyUp(KeyCode.C))
        {
            SceneManager.LoadScene("Credits");
        }

        if(Input.GetKeyUp(KeyCode.M))
        {
            SceneManager.LoadScene("01rocketmodel");
        }
    }

}
