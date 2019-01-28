using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missle : MonoBehaviour
{
    private GameObject Player;

    private AudioSource audioSource;

    public float Speed = 3.0f;
    
    public GameObject Explosion;

    public AudioClip explosionClip;

    public GameObject ExplosionPoint;
    
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        audioSource = Player.GetComponent<AudioSource>();
        target = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //setting always the same Y position
        //follow.y = this.transform.position.y;
        // remenber to use the new 'follow' position, not the Player.transform.position or else it'll move directly to the player
        //this.transform.position = Vector3.MoveTowards(this.transform.position, target, Speed * Time.deltaTime);
        this.transform.Translate(transform.forward * Speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider otherObject)
    {
        if(otherObject.tag == "Player")
        {
            Vector3 position = ExplosionPoint.transform.position;
            Destroy(transform.gameObject);
            GameObject.Instantiate(Explosion, position, Quaternion.identity);
            audioSource.PlayOneShot(explosionClip);
        }
    }
}
