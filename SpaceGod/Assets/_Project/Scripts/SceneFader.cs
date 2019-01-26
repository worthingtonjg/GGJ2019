using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    // Start is called before the first frame update
    public void Load(string scene)
    {
        SimpleSceneFader.ChangeSceneWithFade(scene);
    }
}
