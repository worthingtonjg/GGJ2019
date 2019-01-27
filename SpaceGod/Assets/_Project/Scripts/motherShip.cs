using UnityEngine;

public class motherShip : MonoBehaviour
{
    public ParticleSystem WarpAnimation;
    
    private AudioSource audioSource;
    private GameObject Player;
    public float Speed = 10.0f;
    public AudioClip teleportClip;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        audioSource = Player.GetComponent<AudioSource>();
        WarpAnimation.Play();
        audioSource.PlayOneShot(teleportClip);
        transform.LookAt(Player.transform.position);
    }
    void Update()
    {
        //this.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}