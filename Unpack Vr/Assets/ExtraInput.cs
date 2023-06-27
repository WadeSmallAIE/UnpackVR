using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ExtraInput : MonoBehaviour
{
    [SerializeField] InputActionProperty inputActions;
    XRBaseInteractor interactor;
    // Start is called before the first frame update
    void Start()
    {
        inputActions.action.performed += SpawnGo;
        interactor = GetComponent<XRBaseInteractor>();
    }

    private void OnEnable()
    {
        inputActions.action.Enable();
    }
    private void OnDisable()
    {
        inputActions.action.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpawnGo(InputAction.CallbackContext context)
    {
        Debug.Log("Button Pressed");
        IXRSelectInteractable interactable = interactor.firstInteractableSelected;
        if(interactable != null)
        {
            Debug.Log("interactable isnt null");
            ObjectSpawner spawner;
            if(interactable.transform.TryGetComponent(out spawner))
            {
                spawner.SpawnObject();
            }
        }
    }
}
