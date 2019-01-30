using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class modelViewerController : MonoBehaviour
{
    public string prevScene;
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.B))
        {
            SceneManager.LoadScene(prevScene);
        }
        if(Input.GetKeyUp(KeyCode.N))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
