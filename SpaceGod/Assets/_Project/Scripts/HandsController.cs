using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class HandsController : MonoBehaviour
{
    public GameObject PhotonTorpedoPrefab;
    private GameObject PhotonTorpedo;
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
                // play make fist animation
                Instantiate(PhotonTorpedoPrefab, this.transform.position, this.transform.rotation);

            }
            //else if (interactionSourceState.touchpadTouched && interactionSourceState.touchpadPosition.x > 0.5) // Touchpad moved right
            else if (interactionSourceState.touchpadTouched) // Touchpad touched
            {
                // Change the position of the player to the right
                Instantiate(PhotonTorpedoPrefab, this.transform.position, this.transform.rotation);
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

