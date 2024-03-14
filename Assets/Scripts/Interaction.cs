using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [SerializeField] Transform pcamera;
    [SerializeField] float maxDistance = 6;
    [SerializeField] GameObject interactText;
    [SerializeField] GameObject LightOn;
    PlayerInputAction playerInputAction;
    GameObject worldObj;
    Item.ItemType worldItemType;

    //Inventory
    Inventory inventory;
    [SerializeField] UiInventory inventoryUi;
    [SerializeField] Breaker breaker;

    bool isCollectiable;
    bool isBreaker;
    bool isDoor;
    

    RaycastHit hit;
    private void Awake()
    {
        inventory = new Inventory();
    }
    void Start()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.PlayerMovement.Enable();
        playerInputAction.PlayerMovement.Interaction.performed += c => ObjectPickUp();
        playerInputAction.PlayerMovement.Interaction.performed += c => DoorInteract();
        inventoryUi.SetInventory(inventory);
    }

    private void DoorInteract()
    {
        if(isDoor)
        {
            hit.transform.gameObject.GetComponent<UpdatedDoor>().DoorInteraction();
        }
    }

    private void Update()
    {
       
        if (Physics.Raycast(pcamera.transform.position, pcamera.transform.forward, out hit, maxDistance))
        {
            worldObj = hit.transform.gameObject;

            if (hit.transform.tag == "collectables")
            {
               interactText.SetActive(true);
                
               isCollectiable = true;
            }
            else
            {
                isCollectiable= false;
            }
            if(hit.transform.tag == "Breaker")
            {
                interactText.SetActive(true);
                isBreaker = true;
            }
            else
            {
                isBreaker = false;
            }

            if(hit.transform.tag == "Door" || hit.transform.tag == "MainDoor")
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
 
    void ObjectPickUp()
    {
        if(isCollectiable && inventory.GetItemList().Count<5)
        {
            
            worldItemType = worldObj.GetComponent<WorldItem>().worldItem;
            if (worldItemType == Item.ItemType.Lighter)
            {
                LightOn.SetActive(true);
            }
             inventory.AddItem(new Item { Type = worldItemType, amount = 1 });
             
            Destroy(worldObj);
           
        }

        if (isBreaker)
        {
            breaker.ToggleLights();
        }
    }

}
