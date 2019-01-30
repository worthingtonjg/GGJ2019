using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
    public GameObject Debris;
    public AudioClip finalClip;
    public AudioClip music;

    private AudioSource source;
    

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        source = player.GetComponent<AudioSource>();

        GameObject.Instantiate(Debris, player.transform.position, Quaternion.identity);
        var debris = GameObject.FindGameObjectsWithTag("Debris");
        foreach (var chunk in debris)
        {
            var rb = chunk.GetComponent<Rigidbody>();
            rb.AddRelativeForce(Random.onUnitSphere * 10);
        }

        StartCoroutine(CutScene());
    }

    // Update is called once per frame
    IEnumerator CutScene()
    {
        source.PlayOneShot(finalClip);
        yield return new WaitForSeconds(finalClip.length + 1);
        source.clip = music;
        source.loop = true;
        source.Play();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Credits");
    }
}
