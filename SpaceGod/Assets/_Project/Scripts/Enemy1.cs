using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private GameObject Player;

    private AudioSource audioSource;

    public float Speed = 3.0f;
    public GameObject Explosion;

    public AudioClip explosionClip;

    public GameObject ExplosionPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 follow = Player.transform.position;
        //setting always the same Y position
        //follow.y = this.transform.position.y;
        // remenber to use the new 'follow' position, not the Player.transform.position or else it'll move directly to the player
        this.transform.position = Vector3.MoveTowards(this.transform.position, follow, Speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider otherObject)
    {
        print("1");
        if(otherObject.tag == "Player")
        {
            print("2");
            Vector3 position = ExplosionPoint.transform.position;
            Destroy(transform.gameObject);
            GameObject.Instantiate(Explosion, position, Quaternion.identity);
            audioSource.PlayOneShot(explosionClip);
        }
    }
}
