using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
    }
}
