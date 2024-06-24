using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MapTabController : MonoBehaviour
{
    [SerializeField] Image GroundFloor;
    [SerializeField] Image Basement;
    [SerializeField] Image TopFloor;

    [SerializeField] GameObject TabCanvas;
    PlayerInputAction inputActions;

    bool isTabOpen;
    private void Start()
    {
        inputActions = new PlayerInputAction();
        inputActions.PlayerMovement.Enable();
        inputActions.PlayerMovement.Map.performed += HandleTab;
    }

    private void HandleTab(InputAction.CallbackContext context)
    {
        if (isTabOpen == false) 
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            TabCanvas.SetActive(true);
            TabCanvas.GetComponent<Canvas>().sortingOrder = 5;
            isTabOpen = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            TabCanvas.SetActive(false);
            TabCanvas.GetComponent<Canvas>().sortingOrder = 0;
            isTabOpen =false;
        }
    }

   
    public void OnGroundClick()
    {
        GroundFloor.enabled = true;
        Basement.enabled = false;
        TopFloor.enabled = false;
    }

  
    public void OnTopClick()
    {
        GroundFloor.enabled = false;
        Basement.enabled = false;
        TopFloor.enabled = true;
    }

    public void OnBasementClick()
    {
        GroundFloor.enabled = false;
        TopFloor.enabled = false;
        Basement.enabled = true;
    }
}
