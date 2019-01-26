﻿using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RandomThing", 1);
    }
    
    void RandomThing()
    {
        float randomTime = Random.Range(5.0f, 20.0f);
    
        // do you code
        var newEnemy = GameObject.Instantiate(enemy, this.transform.position, this.transform.rotation);
        Invoke("RandomThing", randomTime);
    
    }
}