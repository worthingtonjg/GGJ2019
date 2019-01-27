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
    
    // Start is called before the first frame update
    void Start()
    {
        PhotonTorpedo = null;
    }

    // Update is called once per frame
    void Update()
    {
        var interactionSourceStates = InteractionManager.GetCurrentReading();
        foreach (var interactionSourceState in interactionSourceStates)
        {
            if (interactionSourceState.selectPressed) // Trigger pressed
            {
                if (Time.time > fireTime + DelayTime)
                {
                    // play make fist animation
                    var instance = Instantiate(PhotonTorpedoPrefab, this.transform.position, this.transform.rotation);
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

