using UnityEngine;

public class motherShip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
    }
}
