﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;

public class levelController : MonoBehaviour
{
    private static TextMeshPro textMesh;
    private Camera camera;
    public static bool battleStarted;
    public static bool battleOver;
    private bool intro1Complete;
    private AudioSource audioSource;
    private GameObject player;

    public ParticleSystem WarpAnimation;

    public AudioClip intro1Clip;

    public AudioClip intro2Clip;

    public AudioClip intro3Clip;

    public AudioClip battleClip;

    public AudioClip levelCompleteClip;
    
    public GameObject Dead1;

    public GameObject Dead2;

    public GameObject Dead3;

    public GameObject Dead4;

    public GameObject Dead5;
    
    public GameObject Explosion;
    
    public AudioClip teleportClip;

    public AudioClip explosionClip;

    public GameObject DropShipSpawn;

    public GameObject EnemyController;
    public GameObject DroneSpawners;
    public GameObject[] spawners;

    public GameObject EscapedProgress;

    public static int dropShipSpawned = 10;

    public static int dropShipTotal = 15;

    public static int dropShipThroughPortal = 0;

    public static int EnemyCount = 15;
    public static bool levelComplete;

    // Start is called before the first frame update
    public void Init()
    {
        // Reset values for play again
        dropShipThroughPortal = 0;
        battleStarted = false;
        intro1Complete = false;
        levelComplete = false;
        EnemyCount = 15;

        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
        audioSource.Stop();
        audioSource.PlayOneShot(intro1Clip);
        textMesh = EscapedProgress.GetComponent<TextMeshPro>();

        StartCoroutine(Intro1Completed());
        InvokeRepeating("RespawnDropship", 15f, 15f);

        foreach(var spawner in spawners)
        {
            var script = spawner.GetComponent<droneSpawner>();
            script.Init();
        }

        textMesh.SetText("Escaped: " + dropShipThroughPortal + " of " + dropShipTotal);
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
            {
                if(hit.transform.name == "Exit")
                {
                    battleStarted = true;
                    audioSource.PlayOneShot(intro2Clip);
                    StartCoroutine(BeginBattle());
                    
                }
            }
        }

        if(EnemyCount == 0 && !levelComplete)
        {
            levelComplete = true;
            audioSource.Stop();
            audioSource.PlayOneShot(levelCompleteClip);
        }

        if(Input.GetKeyUp(KeyCode.X) && EnemyCount > 0)
        {
            EnemyCount = 0;
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
        DroneSpawners.SetActive(true);
        yield return StartCoroutine(Explode(Dead1, 1f));
        yield return StartCoroutine(Explode(Dead2, 1f));
        yield return StartCoroutine(Explode(Dead3, 1f));
//        yield return StartCoroutine(Explode(Dead4, 1f));
//        yield return StartCoroutine(Explode(Dead5, 1f));
        audioSource.PlayOneShot(intro3Clip);
        yield return new WaitForSeconds(intro3Clip.length);
        audioSource.clip = battleClip;
        audioSource.loop = true;
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
        if(dropShipPool.pool.Count > 0 && dropShipSpawned <= dropShipTotal) 
        {
            GameObject ship = dropShipPool.pool[0];
            dropShipPool.pool.RemoveAt(0);
            ship.transform.position = new Vector3(DropShipSpawn.transform.position.x, DropShipSpawn.transform.position.y, DropShipSpawn.transform.position.z);
            ship.SetActive(true);
            audioSource.PlayOneShot(teleportClip);
            WarpAnimation.Play();
            ++dropShipSpawned;
        }
    }

    public static void IncrementEscaped()
    {
        ++dropShipThroughPortal;
        textMesh.SetText("Escaped: " + dropShipThroughPortal + " of " + dropShipTotal);
        //print("Escaped " + dropShipThroughPortal);
    }

}
