using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour
{
    public AudioClip introClip;
    
    private AudioSource audioSource;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
        audioSource.PlayOneShot(introClip);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
