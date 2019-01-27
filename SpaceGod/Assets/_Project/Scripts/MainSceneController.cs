using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneController : MonoBehaviour
{
    GameObject exit;
    GameObject[] enemies;
    GameObject level;

    // Start is called before the first frame update
    public void Init()
    {
        exit = GameObject.Find("Exit");
        var exitScript = exit.GetComponent<exit>();
        exitScript.Init();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            var enemyScript = enemy.GetComponent<motherShip>();
            enemyScript.Init();
        }
        level = GameObject.Find("LevelController");
        var levelScript = level.GetComponent<levelController>();
        levelScript.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
