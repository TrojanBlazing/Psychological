using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{    
  
 [SerializeField] private GameObject LightOn;
    PlayerInputAction playerInputAction;
    public bool lighterInHand;
    int lighterState =0;
    void Start()
    {
        LightOn.SetActive(false);
        playerInputAction = new PlayerInputAction();
        playerInputAction.PlayerMovement.Enable();
        playerInputAction.PlayerMovement.Interaction.performed += c => FireLighter();
    }

    void FireLighter()
    {
        if (lighterInHand)
        {
            if (lighterState == 0)
            {
                LightOn.SetActive(true);
                lighterState = 1;
            }
            else
            {
                LightOn.SetActive(false);
                lighterState = 0;
            }
        }
        else
        {
            LightOn.SetActive(false);
        }
    }
   
}




