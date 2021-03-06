﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
    public ParticleSystem exitParticles;
    public AudioClip teleportClip;
    public GameObject DropShipSpawn;

    private AudioSource audioSource;
    private GameObject player;

    public void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider otherObject)
    {
        if(otherObject.tag == "DropShip")
        {
            //otherObject.transform.position = new Vector3(DropShipSpawn.transform.position.x, DropShipSpawn.transform.position.y, DropShipSpawn.transform.position.z);

            otherObject.transform.gameObject.SetActive(false);
            dropShipPool.pool.Add(otherObject.transform.gameObject);

            exitParticles.Play();
            audioSource.PlayOneShot(teleportClip);

            if(levelController.battleStarted)
            {
                levelController.IncrementEscaped();
            }
        }

        if(levelController.EnemyCount == 0 && levelController.levelComplete)
        {
            if(otherObject.tag == "Player")
            {
                SceneManager.LoadScene("Portal");
            }
        }
    }
}
