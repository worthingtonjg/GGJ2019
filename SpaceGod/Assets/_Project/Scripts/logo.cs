using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logo : MonoBehaviour
{
    public AudioClip clip;

    void Awake()
    {
        StartCoroutine(next());
    }

    private IEnumerator next()
    {
        yield return new WaitForSeconds(clip.length + 1);
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
