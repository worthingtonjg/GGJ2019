using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateController : MonoBehaviour
{
    public int id;
    public GameObject EnemyPrefab;

    public GameObject SpawnedEnemy;

    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Spawn()
    {
        if(SpawnedEnemy != null) return;
        
        SpawnedEnemy = GameObject.Instantiate(EnemyPrefab, transform.position, transform.rotation);
        SpawnedEnemy.transform.LookAt(Player.transform);
    }

    public void DeSpawn()
    {
        GameObject.Destroy(SpawnedEnemy);
        SpawnedEnemy = null;
    }
}
