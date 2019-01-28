using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserCannon : MonoBehaviour
{
    public GameObject projectile;
    public float shootRate;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", shootRate, shootRate);
    }

    // Update is called once per frame
    void Shoot()
    {
        var instance = GameObject.Instantiate(projectile, transform.position, transform.rotation);
        GameObject.Destroy(instance, 6);
    }
}
