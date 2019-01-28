using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuButtonHit : MonoBehaviour
{
    public string sceneName;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Torpedo")
        {
            SceneManager.LoadScene(sceneName);
            //print("hit");
        }
    }
}
