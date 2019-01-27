using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        
    }

    public void LoadDropShipViewer()
    {
        SimpleSceneFader.ChangeSceneWithFade("dropshipmodel");
    }

    public void TargetHit(object name)
    {
        print("Target Hit Method");
        if(name.ToString() == "StartGame")
        {
            SceneManager.LoadScene("MainScene");
        }

        if (name.ToString() == "ModelViewer")
        {
            SceneManager.LoadScene("rocketmodel");
        }

        if (name.ToString() == "Credits")
        {
            SceneManager.LoadScene("Credits");
        }

    }
}
