using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private GameObject Spawner;
    public GameObject Enemy;
    void Start()
    {
        Invoke("RandomThing", 1);
    }

    // Update is called once per frame
    void RandomThing()
    {
        float randomTime = Random.Range(0.1f, 5.0f);

        GameObject[] list = GameObject.FindGameObjectsWithTag("Respawn");
        int randomSpawn = Random.Range(0, (list.Length));
        Spawner = list[randomSpawn];
    
        var newEnemy = GameObject.Instantiate(Enemy, Spawner.transform.position, Spawner.transform.rotation);
        Invoke("RandomThing", randomTime);
    }
}
