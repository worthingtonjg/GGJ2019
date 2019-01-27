using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.WSA.Input;
using static HoloToolkit.Unity.InputModule.MotionControllerInfo;

public class HandsController : MonoBehaviour
{
    private const float DelayTime = 0.5f;
    public GameObject PhotonTorpedoPrefab;
    private GameObject PhotonTorpedo;
    private float fireTime;
    public float speed = 1f;

    private Transform leftHandTransform;
    private Transform rightHandTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        PhotonTorpedo = null;
        var motionControllers = GameObject.Find("MotionControllers");
        var motionScript = motionControllers.GetComponent<MotionControllerVisualizer>();
        motionScript.OnControllerModelLoaded += MotionScript_OnControllerModelLoaded;
    }

    private void MotionScript_OnControllerModelLoaded(MotionControllerInfo obj)
    {
        if(obj.Handedness == InteractionSourceHandedness.Left)
        {
            Transform t;
            obj.TryGetElement(ControllerElementEnum.PointingPose, out t);
            leftHandTransform = t;
        }

        if(obj.Handedness == InteractionSourceHandedness.Right)
        {
            Transform t;
            obj.TryGetElement(ControllerElementEnum.PointingPose, out t);
            rightHandTransform = t;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        var interactionSourceStates = InteractionManager.GetCurrentReading();
        foreach (var interactionSourceState in interactionSourceStates)
        {
            //interactionSourceState.source.handedness == InteractionSourceHandedness.Left
            if (interactionSourceState.selectPressed) // Trigger pressed
            {
                if (Time.time > fireTime + DelayTime)
                {
                    Transform source;
                    if(interactionSourceState.source.handedness == InteractionSourceHandedness.Left)
                    {
                        source = leftHandTransform;
                    }
                    else
                    {
                        source = rightHandTransform;
                    }

                    // play make fist animation
                    var instance = Instantiate(PhotonTorpedoPrefab, source.position, source.rotation);
                    GameObject.Destroy(instance.gameObject, 10f);
                    fireTime = Time.time;
                }
            }

            if (interactionSourceState.touchpadTouched) 
            {
                if (SceneManager.GetActiveScene().name == "MainScene")
                {
                    // Change the position of the player to the right
                    transform.Translate(-1 * rightHandTransform.forward * speed * Time.deltaTime);
                }

            }

            /*
                        else if (interactionSourceState.touchpadTouched && interactionSourceState.touchpadPosition.x > 0.5) // Touchpad moved right
                        {
                            if (SceneManager.GetActiveScene().name == "MainScene")
                            {
                                // Change the position of the player to the right
                                transform.Translate(-1 rightHandTransform.forward * speed * Time.deltaTime);
                            }

                        }
                        else if (interactionSourceState.touchpadTouched && interactionSourceState.touchpadPosition.x < -0.5) // Touchpad moved left
                        {
                            if (SceneManager.GetActiveScene().name == "MainScene")
                            {
                                // Change the position of the player to the left
                                transform.Translate(Vector3.left * speed * Time.deltaTime);
                            }
                        }
                        else if (interactionSourceState.touchpadTouched && interactionSourceState.touchpadPosition.y > 0.5) // Touchpad moved up
                        {
                            if (SceneManager.GetActiveScene().name == "MainScene")
                            {
                                // Change the position of the player forward
                                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                            }
                        }
                        else if (interactionSourceState.touchpadTouched && interactionSourceState.touchpadPosition.y < -0.5) // Touchpad moved down
                        {
                            if (SceneManager.GetActiveScene().name == "MainScene")
                            {
                                // Change the position of the player backward
                                transform.Translate(Vector3.back * speed * Time.deltaTime);
                            }
                        }
            */
        }
    }
}

