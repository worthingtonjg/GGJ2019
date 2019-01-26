using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class BasicFly : MonoBehaviour {

	public float rotationSpeed = 100.0f;
	public float moveSpeed = 100f;
	public float viewRange = 45f;
	
	private float yaw = 0f;
	private float pitch = 0f;

	// Use this for initialization
	void Awake() 
	{
        #if UNITY_EDITOR
        	Cursor.lockState = CursorLockMode.None;
        	Cursor.visible = true;
        #endif
        
        #if UNITY_STANDALONE
        	Cursor.lockState = CursorLockMode.Locked;
        	Cursor.visible = false;
        #endif

		Camera camera = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update () {

		yaw += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
		pitch -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
		pitch = Mathf.Clamp(pitch, -viewRange, viewRange); 

		transform.eulerAngles = new Vector3(0f, yaw, 0f);
		transform.eulerAngles = new Vector3(pitch, yaw, 0f);

		Vector3 moveDir = transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
		moveDir += transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
		
		if(moveDir.magnitude > 0f)
		{
			transform.Translate(moveDir, Space.World);
		}
	}
}