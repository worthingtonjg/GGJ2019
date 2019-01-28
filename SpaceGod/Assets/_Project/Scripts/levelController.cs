using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour
{
    private Camera camera;
    private bool battleStarted;
    private bool intro1Complete;
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

    public GameObject DropShipSpawn;

    public GameObject EnemyController;

    // Start is called before the first frame update
    public void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
        audioSource.PlayOneShot(intro1Clip);

        StartCoroutine(Intro1Completed());
        InvokeRepeating("RespawnDropship", 15f, 15f);
    }

    void Update()
    {
        if(camera == null)
        {
            camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }

        if(intro1Complete && !battleStarted)
        {
            Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
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

    IEnumerator Intro1Completed()
    {
        yield return new WaitForSeconds(intro1Clip.length);
        intro1Complete = true;
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
        
        ship.SetActive(false);
        dropShipPool.pool.Add(ship);
        
        GameObject.Instantiate(Explosion, position, Quaternion.identity);
        audioSource.PlayOneShot(explosionClip);

        yield return  new WaitForSeconds(wait);
    }

    void RespawnDropship()
    {
        if(dropShipPool.pool.Count > 0) 
        {
            GameObject ship = dropShipPool.pool[0];
            dropShipPool.pool.RemoveAt(0);
            ship.transform.position = new Vector3(DropShipSpawn.transform.position.x, DropShipSpawn.transform.position.y, DropShipSpawn.transform.position.z);
            ship.SetActive(true);
        }
    }

}
