using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightPickUp : MonoBehaviour
{
    public GameObject pickupText;
    public GameObject FlashOn;
    public float interactionDistance = 5.0f;

    private bool interactable;

    void Start()
    {
        FlashOn.SetActive(false);
        pickupText.SetActive(false);
    }

    void Update()
    {
        if (Camera.main != null)
        {

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                if (hit.collider.CompareTag("FlashlightPickup"))
                {
                    pickupText.SetActive(true);
                    interactable = true;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PickUpFlashlight();
                    }
                }
                else
                {
                    pickupText.SetActive(false);
                    interactable = false;
                }
            }
            else
            {
                pickupText.SetActive(false);
                interactable = false;
            }
        }
    }

    void PickUpFlashlight()
    {
        gameObject.SetActive(false); 
        FlashOn.SetActive(true);    
        pickupText.SetActive(false); 
    }
}


