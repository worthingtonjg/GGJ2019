using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour
{
    private bool battleStarted;
    private AudioSource audioSource;
    private GameObject player;

    public AudioClip intro1Clip;

    public AudioClip intro2Clip;

    public AudioClip intro3Clip;
    
    public GameObject Dead1;

    public GameObject Dead2;

    public GameObject Dead3;

    public GameObject Dead4;

    public GameObject Dead5;
    
    public GameObject Explosion;

    public AudioClip explosionClip;

    public GameObject EnemyController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
        audioSource.PlayOneShot(intro1Clip);
    }

    void Update()
    {
        if(!battleStarted)
        {
            Ray ray = player.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                if(hit.transform.name == "Exit")
                {
                    battleStarted = true;
                    audioSource.PlayOneShot(intro2Clip);
                    StartCoroutine(BeginBattle());
                    
                }
            }

    }

    IEnumerator BeginBattle()
    {
        yield return new WaitForSeconds(intro2Clip.length + 1);
        EnemyController.SetActive(true);
        yield return StartCoroutine(Explode(Dead1, 1f));
        yield return StartCoroutine(Explode(Dead2, 1f));
        yield return StartCoroutine(Explode(Dead3, 1f));
        yield return StartCoroutine(Explode(Dead4, 1f));
        yield return StartCoroutine(Explode(Dead5, 1f));
        audioSource.PlayOneShot(intro3Clip);
        yield return new WaitForSeconds(intro3Clip.length);
        audioSource.Play();
    }

    IEnumerator Explode(GameObject ship, float wait)
    {
        Vector3 position = ship.transform.position;
        Destroy(ship.gameObject);
        GameObject.Instantiate(Explosion, position, Quaternion.identity);
        audioSource.PlayOneShot(explosionClip);

        yield return  new WaitForSeconds(wait);
    }

}
