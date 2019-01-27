using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SimpleSceneFader.ChangeSceneWithFade("MainScene");
    }

    public void LoadDropShipViewer()
    {
        SimpleSceneFader.ChangeSceneWithFade("dropshipmodel");
    }
}
