using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropShipExploder : MonoBehaviour
{
    private AudioSource audioSource;
    private GameObject Player;
    public GameObject Explosion;
    public AudioClip explosionClip;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player == null)
        {
            print("Audio Source in dropShipExploder.cs line 15 is null.");
        }
        audioSource = Player.GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Torpedo" || collision.gameObject.name == "missle")
        {
            if (audioSource == null)
            {
                print("Audio Source in dropShipExploder.cs on line 25 is null.");
                if (Player == null)
                {
                    Player = GameObject.FindGameObjectWithTag("Player") as GameObject;
                }
                audioSource = Player.GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    print("Audio Source in dropShipExploder.cs on line 34 is null.");
                }
            }

            audioSource.PlayOneShot(explosionClip);
            Vector3 position = transform.position;
            Instantiate(Explosion, position, Quaternion.identity);
        }
    }
}
