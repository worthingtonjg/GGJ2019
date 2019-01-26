﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private GameObject Spawner;
    public GameObject Enemy;

    public float minSpawn = 0.1f;
    public float maxSpawn = 5.0f;
    void Start()
    {
        Invoke("RandomThing", 1);
    }

    // Update is called once per frame
    void RandomThing()
    {
        float randomTime = Random.Range(minSpawn, maxSpawn);

        GameObject[] list = GameObject.FindGameObjectsWithTag("Respawn");
        int randomSpawn = Random.Range(0, (list.Length));
        Spawner = list[randomSpawn];
    
        var newEnemy = GameObject.Instantiate(Enemy, Spawner.transform.position, Spawner.transform.rotation);
        Invoke("RandomThing", randomTime);
    }
}
