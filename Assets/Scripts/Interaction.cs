using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Transform pcamera;
    [SerializeField] private float maxDistance = 6;
    [SerializeField] GameObject text;

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
        if(isDoor && hit.transform.gameObject.tag == "MainDoor")
        {
          
            if(hit.transform.gameObject.GetComponent<Door>().mainDoorLocked == false)
            {
                
                hit.transform.gameObject.GetComponent<Door>().PressCheck();
            }
        }
        else if(isDoor)
        {
            hit.transform.gameObject.GetComponent<Door>().PressCheck();
        }
    }

    private void Update()
    {
       
        if (Physics.Raycast(pcamera.transform.position, pcamera.transform.forward, out hit, maxDistance))
        {
            worldObj = hit.transform.gameObject;

            if (hit.transform.tag == "collectables")
            {
               text.SetActive(true);
                
               isCollectiable = true;
            }
            else
            {
                isCollectiable= false;
            }
            if(hit.transform.tag == "Breaker")
            {
                text.SetActive(true);
                isBreaker = true;
            }
            else
            {
                isBreaker = false;
            }

            if(hit.transform.tag == "Door" || hit.transform.tag == "MainDoor")
            {
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
            //Debug.Log(worldItemType);
             inventory.AddItem(new Item { Type = worldItemType, amount = 1 });
          
            Destroy(worldObj);
        }

        if (isBreaker)
        {
            breaker.ToggleLights();
        }
    }

}
