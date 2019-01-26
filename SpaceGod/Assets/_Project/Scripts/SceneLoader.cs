using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Threading;
using System;

public class SceneLoader : MonoBehaviour
{
    public UnityEvent SceneLoaded;

    public List<string> Scenes;
    
    private Scene rootScene;
    private int loadedCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rootScene = SceneManager.GetActiveScene();
        
        foreach(var scene in Scenes)
        {
            StartCoroutine(LoadSceneAsync(scene));
        }
    }

    // Update is called once per frame
    IEnumerator LoadSceneAsync(string sceneName)
    {

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
       
        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Get a reference to the root game object in the child scene and rename it
        var root = GameObject.Find("Root");
        root.name = sceneName;

        // Move it into your main scene
        SceneManager.MoveGameObjectToScene(root, rootScene);

        // Unload the child scene 
        SceneManager.UnloadSceneAsync(sceneName);

        ++loadedCount;

        // If all the children scenes have been loaded then call the SceneLoaded Event
        if(loadedCount == Scenes.Count)
        {
            if(SceneLoaded != null)
            {
                SceneLoaded.Invoke();
            }
        }
    }
}