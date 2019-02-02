using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debrisController : MonoBehaviour
{
    public GameObject Explosion;
    public AudioClip explosionClip;

    private GameObject Player;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        audioSource = Player.GetComponent<AudioSource>();

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Torpedo")
        {
            if (audioSource == null)
            {
                print("Audio Source in debrisController.cs on line 38 is null.");
                if (Player == null)
                {
                    Player = GameObject.FindGameObjectWithTag("Player") as GameObject;
                }
                audioSource = Player.GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    print("Audio Source in debrisController.cs on line 46 is null.");
                }
            }

            audioSource.PlayOneShot(explosionClip);
            Vector3 position = transform.position;
            Instantiate(Explosion, position, Quaternion.identity);
        }
    }
}
