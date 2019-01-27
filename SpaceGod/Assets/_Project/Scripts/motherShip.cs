using UnityEngine;

public class motherShip : MonoBehaviour
{
    public ParticleSystem WarpAnimation;
    
    private AudioSource audioSource;
    private GameObject Player;
    public float floatStrength = 0.1f;
    private float random;
    public AudioClip teleportClip;

    public GameObject Explosion;
    public AudioClip explosionClip;
    private Vector3 target;


    // Start is called before the first frame update
    public void Init()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        audioSource = Player.GetComponent<AudioSource>();
        WarpAnimation.Play();
        audioSource.PlayOneShot(teleportClip);
        transform.LookAt(Player.transform.position);
        random = Random.Range(1, 360);
    }
    void Update()
    {
        //position y
        this.transform.position = new Vector3(this.transform.position.x + ((float)Mathf.Sin(Time.time) * floatStrength),
            this.transform.position.y,
            this.transform.position.z); 

        //position y
        this.transform.position = new Vector3(this.transform.position.x,
            this.transform.position.y + ((float)Mathf.Cos(Time.time - this.random) * floatStrength),
            this.transform.position.z); 

        //position z
        this.transform.position = new Vector3(this.transform.position.x,
            this.transform.position.y,
            this.transform.position.z - ((float)Mathf.Cos(Time.time) * floatStrength)); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Torpedo")
        {
            audioSource.PlayOneShot(explosionClip);
            Vector3 position = transform.position;
            Instantiate(Explosion, position, Quaternion.identity);
        }
    }
}