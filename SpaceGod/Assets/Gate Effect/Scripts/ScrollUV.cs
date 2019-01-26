using UnityEngine;
using System.Collections;

public class ScrollUV : MonoBehaviour {
	public Vector2 	direction 	= 	new Vector2(0,1);
	public float	speed		= 	1;
	void Update () {
		GetComponent<Renderer>().material.mainTextureOffset += direction * speed * Time.deltaTime;
		//renderer.material.SetTextureOffset("_BumpMap", renderer.material.mainTextureOffset);
	}
}
