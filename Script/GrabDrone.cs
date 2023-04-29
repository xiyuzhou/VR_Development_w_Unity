using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class GrabDrone : MonoBehaviour
{
    private XRSimpleInteractable interactable;
    private bool isGrabbing;
    public Transform xrRig;

    private void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        isGrabbing = false;
    }

    public void Grab2()
    {
        isGrabbing = true;
    }
}
