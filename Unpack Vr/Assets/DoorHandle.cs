using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorHandle : MonoBehaviour
{
    public float ditance;
    XRGrabInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();   
    }

    // Update is called once per frame
    void Update()
    {
        IXRSelectInteractor interactor = interactable.firstInteractorSelecting;
        if (interactor != null)
        {
            if(Vector3.Distance(interactor.transform.position, transform.position) >= ditance)
            {
                interactable.enabled = false;
               
            }
            
        }
        else { interactable.enabled = true; }
    }
}
