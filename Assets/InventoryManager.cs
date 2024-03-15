using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> inventory = new List<Item>(); // List to store collected items
    public int currentItemIndex = 0; // Index of the currently selected worldItem in inventory
    public Transform handPosition; // Position where the worldItem will be visible in the player's hand
    [SerializeField] GameObject[] itemPrefabs;
    [SerializeField] Vector3 objectScaleWhenInInventory;
    void Update()
    {
        // Scroll through the inventory using the mouse scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (inventory.Count > 0) // Check if inventory is not empty
        {
            if (scroll != 0)
            {
                currentItemIndex += (int)Mathf.Sign(scroll);
                if (currentItemIndex < 0)
                    currentItemIndex = inventory.Count - 1;
                else if (currentItemIndex >= inventory.Count)
                    currentItemIndex = 0;
                UpdateHandItem();
            }
        }

        // Drop the currently held worldItem when 'g' key is pressed
        if (Input.GetKeyDown(KeyCode.G) && inventory.Count > 0)
        {
            DropItem();
        }
    }

    void UpdateHandItem()
    {
        // Clear hand position
        foreach (Transform child in handPosition)
        {
            Destroy(child.gameObject);
        }

        // Instantiate the selected worldItem at the hand position
        if (inventory.Count > 0)
        {
            foreach (GameObject i in itemPrefabs)
            {
                if(i.GetComponent<Item>().itemType == inventory[currentItemIndex].itemType)
                {
                   GameObject newGameObject = Instantiate(itemPrefabs[currentItemIndex], handPosition.position, Quaternion.identity, handPosition);
                    newGameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    newGameObject.GetComponent<Transform>().localScale = objectScaleWhenInInventory;
                }

            }
            //Instantiate(inventory[currentItemIndex].gameObject, handPosition.position, Quaternion.identity, handPosition);
        }
    }

    void DropItem()
    {
        // Instantiate the currently held worldItem in the world and remove it from inventory
         GameObject newGameObject =  Instantiate(inventory[currentItemIndex].gameObject, handPosition.position, Quaternion.identity);
       // newGameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        inventory.RemoveAt(currentItemIndex);

        // Update current index if it exceeds inventory count
        if (currentItemIndex >= inventory.Count)
            currentItemIndex = Mathf.Max(0, inventory.Count - 1);

        // Update the hand worldItem after dropping
        UpdateHandItem();
    }

    // Add an worldItem to the inventory
    public void AddItem(Item worldItem)
    {
        if (worldItem.isCollectible && inventory.Count < 5)
        {
            foreach (GameObject i in itemPrefabs)
            {
                if(worldItem.itemType == i.GetComponent<Item>().itemType)
                {
                    inventory.Add(i.GetComponent<Item>());
                    
                }
            }
            //inventory.Add(worldItem);
           
            
           
            UpdateHandItem();
           

        }
        else
        {
            Debug.LogWarning("Item cannot be added to inventory!");
        }
    }
}
