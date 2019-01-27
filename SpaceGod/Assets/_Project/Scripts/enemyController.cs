using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    private GameObject Spawner;
    private GameObject Player;
    
    public GameObject MisslePrefab;
    public float minSpawn = 0.1f;
    public float maxSpawn = 5.0f;
    
    public GameObject[] enemyShips;
    void Start()
    {
        enemyShips = GameObject.FindGameObjectsWithTag("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");
        
        Invoke("Fire", 1);
    }

    // Update is called once per frame
    void Fire()
    {
        float randomTime = Random.Range(minSpawn, maxSpawn);
        
        int randomSpawn = Random.Range(0, (enemyShips.Length));
        Spawner = enemyShips[randomSpawn];

        if (Spawner != null)
        {
            var newEnemy = GameObject.Instantiate(MisslePrefab, Spawner.transform.position, Spawner.transform.rotation);
            newEnemy.transform.LookAt(Player.transform);
            Invoke("Fire", randomTime);
        }
    }
}
