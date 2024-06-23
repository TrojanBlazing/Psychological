
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class pickupItem : MonoBehaviour
{
    [SerializeField] private GameObject obj, intText;
    private bool interactable;
    [SerializeField] private float interactionDistance = 5.0f;

    PlayerInputAction pa;
    private InputAction interactAction;

    private void Awake()
    {
        pa = new PlayerInputAction();
    }

    private void OnEnable()
    {
        pa.PlayerMovement.Enable();
        interactAction = pa.PlayerMovement.Interaction; 
        interactAction.performed += OnInteractPerformed;
    }

    private void OnDisable()
    {
        interactAction.performed -= OnInteractPerformed;
        pa.PlayerMovement.Disable();
    }

    void Update()
    {
        if (Camera.main != null)
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                if (hit.transform.CompareTag("Pick"))
                {
                    intText.SetActive(true);
                    interactable = true;
                }
                else
                {
                    intText.SetActive(false);
                    interactable = false;
                }
            }
            else
            {
                intText.SetActive(false);
                interactable = false;
            }
        }
    }

    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        if (interactable)
        {
            intText.SetActive(false);
            obj.SetActive(false);
            interactable = false;
        }
    }
}
