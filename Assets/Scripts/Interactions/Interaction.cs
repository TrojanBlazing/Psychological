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
    [SerializeField] LayerMask interactableObjectsMask;
    PlayerInputAction playerInputAction;
    [SerializeField] PlayerUI playerUI;
    bool isCollectiable;
    bool isBreaker;
    bool isDoor;
    internal bool isCandle;
    RaycastHit hit;

    void Start()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.PlayerMovement.Enable();
       // playerInputAction.PlayerMovement.Interaction.performed += c => ObjectPickUp();
      
    }
  

    private void Update()
    {
        playerUI.UpdateText(string.Empty);
        if (Physics.Raycast(pcamera.transform.position, pcamera.transform.forward, out hit, maxDistance , interactableObjectsMask))
        {  

           if(hit.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if(playerInputAction.PlayerMovement.Interaction.triggered)
                {
                    if (hit.transform.CompareTag("collectables") && inventoryManager!= null)
                    {
                            Item item = hit.transform.GetComponent<Item>(); // Assuming your collectible object has the Item script attached
                            if (item != null)
                            {
                                inventoryManager.AddItem(item);
                                Destroy(hit.transform.gameObject);
                            }
                        
                    }
                    interactable.BaseInteract();
                }
            }
           /*
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
            if (hit.transform.CompareTag("Candle"))
            {
                interactText.SetActive(true);
                isCandle = true;
            }
            else
            {
               
                isCandle = false;
            }*/
        }
        
        if(inventoryManager.inventory.Count > 0)
        {
            gameObject.GetComponent<PlayerMovement>().canHeadBob = false;
        }
        else
        {
            gameObject.GetComponent<PlayerMovement>().canHeadBob = true;
        }

    }

    public RaycastHit InteractObjInfo()
    {
        return hit;
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
            hit.transform.gameObject.GetComponent<Door>().DoorInteraction();
        }
    }
   
}
