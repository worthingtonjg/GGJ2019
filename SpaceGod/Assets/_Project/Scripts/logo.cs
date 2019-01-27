using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(next());
    }

    private IEnumerator next()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
