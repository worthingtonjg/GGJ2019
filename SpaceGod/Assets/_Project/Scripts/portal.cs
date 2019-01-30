using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public GameObject PortalPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        
        Vector3 position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 10);
        
        GameObject.Instantiate(PortalPrefab, position, player.transform.rotation);
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Home");
    }

}
