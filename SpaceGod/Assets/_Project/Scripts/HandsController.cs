using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class HandsController : MonoBehaviour
{
    private const float DelayTime = 0.5f;
    public GameObject PhotonTorpedoPrefab;
    private GameObject PhotonTorpedo;
    private float fireTime;

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
            leftHandTransform = obj.ControllerParent.transform;
        }

        if(obj.Handedness == InteractionSourceHandedness.Right)
        {
            rightHandTransform = obj.ControllerParent.transform;
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
            //else if (interactionSourceState.touchpadTouched && interactionSourceState.touchpadPosition.x > 0.5) // Touchpad moved right
            else if (interactionSourceState.touchpadTouched) // Touchpad touched
            {
                // Change the position of the player to the right
            }
            //else if (interactionSourceState.touchpadTouched && interactionSourceState.touchpadPosition.x < -0.5) // Touchpad moved left
            //{
            //    // Change the position of the player to the left

            //}
            //else if (interactionSourceState.touchpadTouched && interactionSourceState.touchpadPosition.y > 0.5) // Touchpad moved up
            //{
            //    // Change the position of the player forward


            //}
            //else if (interactionSourceState.touchpadTouched && interactionSourceState.touchpadPosition.y < -0.5) // Touchpad moved down
            //{
            //    // Change the position of the player backward

            //}
        }
    }
}

