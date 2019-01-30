using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditsController : MonoBehaviour
{
    public GameObject Stop;

    public GameObject Out;

    public GameObject[] sections;

    private int current = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(-69, 33, -105);

        StartCoroutine(RollCredits());
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    IEnumerator RollCredits()
    {
        if(current > 0)
        {
            sections[current-1].transform.DOMove(Out.transform.position, 3, false);

            if(current >= sections.Length)
            {
                StartCoroutine(NextScene());
            }
        }

        if(current < sections.Length)        
        {
            sections[current].transform.DOMove(Stop.transform.position, 3, false);
        }

        current++;
        yield return new WaitForSeconds(6f);

        if(current <= sections.Length)
        {
            StartCoroutine(RollCredits());
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }
}
