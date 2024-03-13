using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdatedDoor : MonoBehaviour
{


    public float interactDistance = 3f; 
    public float openAngle = 90f;  
    public float openSpeed = 2f;   
    public TextMeshProUGUI interactText;      

    private Quaternion openRotation;
    private Quaternion closedRotation;
    private Quaternion targetRotation;

    void Start()
    {
      
        openRotation = Quaternion.Euler(0f, openAngle, 0f);
        closedRotation = Quaternion.Euler(0f, 0f, 0f);

     
        //targetRotation = closedRotation;

       
        if (interactText != null)
        {
            interactText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("Door"))
            {
           
                if (interactText != null)
                {
                    interactText.gameObject.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    ToggleDoor();
                }
            }
            else
            {
              
                if (interactText != null)
                {
                    interactText.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            
            if (interactText != null)
            {
                interactText.gameObject.SetActive(false);
            }
        }

      
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, openSpeed * Time.deltaTime);
    }

    public void ToggleDoor()
    {
        if (targetRotation == openRotation)
        {
           
            targetRotation = closedRotation;
        }
        else
        {
            
            targetRotation = openRotation;
        }
    }
}

