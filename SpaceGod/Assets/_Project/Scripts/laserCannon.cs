using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserCannon : MonoBehaviour
{
    public GameObject projectile;
    public float shootRate;
    public float projectileSpeed = 20f;
    public float projectileLife = 3f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", shootRate, shootRate);
    }

    // Update is called once per frame
    void Shoot()
    {
        var instance = GameObject.Instantiate(projectile, transform.position, transform.rotation);
        instance.GetComponent<Rigidbody>().velocity = gameObject.transform.TransformDirection(new Vector3(0, 0, projectileSpeed));
        GameObject.Destroy(instance, projectileLife);
    }
}
