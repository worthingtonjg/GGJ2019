using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoController : MonoBehaviour
{
    public float speed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (speed == 0)
        {
            speed = 80;
        }
        transform.Translate(-1 * Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Torpedo")
        {
            if (collision.gameObject.tag != "Menu")
            {
                GameObject.Destroy(collision.gameObject);
            }

            GameObject.Destroy(gameObject);
        }
    }
}
