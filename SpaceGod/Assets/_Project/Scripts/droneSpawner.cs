using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int maxSpawn = 3;

    public float SpawnSpeed = 10f;

    private int spawnCount = 0;

    // Start is called before the first frame update
    public void Init()
    {

    }

    public void Start()
    {
        InvokeRepeating("Spawn", 1f, SpawnSpeed);
    }


    // Update is called once per frame
    void Spawn()
    {
        if(spawnCount >= maxSpawn) 
        {
            CancelInvoke();
        }
        else
        {
            ++spawnCount;
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
