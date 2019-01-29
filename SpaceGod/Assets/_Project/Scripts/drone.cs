using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drone : MonoBehaviour
{
    public enum EnumTarget
    {
        Player,
        DropShip,
        WayPoint,
    }
    
    public EnumTarget? targetType;

    public float minDistance = 3;

    public float speed = 1;

    public GameObject Explosion;
    
    public AudioClip explosionClip;

    private AudioSource audioSource;
    private GameObject Player;

    private GameObject player;
    private GameObject[] dropShips;
    private GameObject[] wayPoints;

    private GameObject target;
    private float distanceToTarget;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dropShips = GameObject.FindGameObjectsWithTag("DropShip");
        wayPoints = GameObject.FindGameObjectsWithTag("WayPoints");

        FindTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null || distanceToTarget < minDistance)
        {
            FindTarget();
        }

        distanceToTarget = Vector3.Distance(this.transform.position, target.transform.position);
        transform.LookAt(target.transform.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void FindTarget()
    {
        if(targetType == null || targetType == EnumTarget.WayPoint)
        {
            targetType = (EnumTarget)Random.Range(0, 2);
            if(targetType == EnumTarget.DropShip)
            {
                target = dropShips[Random.Range(0, dropShips.Length)];
            }
            else
            {
                target = player;
            }
        }
        else
        {
            targetType = EnumTarget.WayPoint;

            target = wayPoints[Random.Range(0, wayPoints.Length)];
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Torpedo")
        {
            if (audioSource == null)
            {
                print("Audio Source in drone.cs on line 83 is null.");
                if (Player == null)
                {
                    Player = GameObject.FindGameObjectWithTag("Player") as GameObject;
                }
                audioSource = Player.GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    print("Audio Source in drone.cs on line 90 is null.");
                }
            }

            audioSource.PlayOneShot(explosionClip);
            Vector3 position = transform.position;
            Instantiate(Explosion, position, Quaternion.identity);
        }
    }
}
