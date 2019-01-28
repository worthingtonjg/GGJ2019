using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int maxSpawn = 3;

    private int spawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 5, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnCount >= maxSpawn) 
        {
            CancelInvoke();
        }

        Instantiate(prefab, transform.position, transform.rotation);
    }
}
