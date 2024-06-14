using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupItem : MonoBehaviour
{
    [SerializeField] private GameObject obj, intText;
    private bool interactable;
    [SerializeField] private float interactionDistance = 5.0f;

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.transform.CompareTag("Pick"))
            {
                intText.SetActive(true);
                interactable = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    intText.SetActive(false);
                    obj.SetActive(false);
                    interactable = false;
                }
            }
        }
        else
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
}
