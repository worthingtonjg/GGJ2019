using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	public Vector3 direction = new Vector3(0,1,0);
	public float 	speed = 1;
	
	void Update () {
		transform.Rotate(direction, speed * Time.deltaTime);
	}
}
