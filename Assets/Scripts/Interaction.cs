using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Interaction : MonoBehaviour
{
    [SerializeField] Transform pcamera;
    [SerializeField] float maxDistance = 6;
    [SerializeField] GameObject interactText;
    [SerializeField] GameObject LightOn;
    [SerializeField] InventoryManager inventoryManager; // Reference to the InventoryManager script
    [SerializeField] Breaker breaker;
    [SerializeField] float delayTime;
    PlayerInputAction playerInputAction;

    bool isCollectiable;
    bool isBreaker;
    bool isDoor;
    RaycastHit hit;

    void Start()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.PlayerMovement.Enable();
        playerInputAction.PlayerMovement.Interaction.performed += c => ObjectPickUp();
      
    }
  

    private void Update()
    {

        if (Physics.Raycast(pcamera.transform.position, pcamera.transform.forward, out hit, maxDistance))
        {  
            if (hit.transform.CompareTag("collectables"))
            {
                interactText.SetActive(true);
                isCollectiable = true;
            }
            else
            {
                isCollectiable = false;
            }
            if (hit.transform.CompareTag("Breaker"))
            {
                interactText.SetActive(true);
                isBreaker = true;
            }
            else
            {
                isBreaker = false;
            }

            if (hit.transform.CompareTag("Door") || hit.transform.CompareTag("MainDoor"))
            {
                interactText.SetActive(true);
                isDoor = true;
            }
            else
            {
                isDoor = false;
            }
        }


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(pcamera.transform.position, pcamera.transform.forward * maxDistance);
    }
    void ObjectPickUp()
    {
        if (isCollectiable && inventoryManager != null)
        {
            Item item = hit.transform.GetComponent<Item>(); // Assuming your collectible object has the Item script attached
            if (item != null)
            {
                inventoryManager.AddItem(item);
                Destroy(hit.transform.gameObject);
            }
        }

        if (isBreaker)
        {
            breaker.ToggleLights();
        }
        if (isDoor)
        {
            hit.transform.gameObject.GetComponent<UpdatedDoor>().DoorInteraction();
        }
    }
   
}
