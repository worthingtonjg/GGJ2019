using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    public bool battleStarted;
    public int Escaped;
    public ParticleSystem exitParticles;
    public AudioClip teleportClip;
    private AudioSource audioSource;
    private GameObject player;

    public void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider otherObject)
    {
        if(otherObject.tag == "DropShip")
        {
            GameObject.Destroy(otherObject.transform.gameObject);
            exitParticles.Play();
            audioSource.PlayOneShot(teleportClip);

            if(battleStarted)
            {
                ++Escaped;
            }
        }
    }
}
