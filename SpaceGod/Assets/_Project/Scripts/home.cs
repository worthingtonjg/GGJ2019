using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
    public GameObject Debris;
    public AudioClip finalClip;
    public AudioClip music;

    private GameObject Player;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        audioSource = Player.GetComponent<AudioSource>();

        GameObject.Instantiate(Debris, Player.transform.position, Quaternion.identity);
        var debris = GameObject.FindGameObjectsWithTag("Debris");
        foreach (var chunk in debris)
        {
            var rb = chunk.GetComponent<Rigidbody>();
            rb.AddRelativeForce(Random.onUnitSphere * 10);
        }

        StartCoroutine(CutScene());
    }

    IEnumerator CutScene()
    {
        audioSource.PlayOneShot(finalClip);
        yield return new WaitForSeconds(finalClip.length + 1);
        audioSource.clip = music;
        audioSource.loop = true;
        audioSource.Play();
        yield return new WaitForSeconds(30f);
        SceneManager.LoadScene("Credits");
    }
}
