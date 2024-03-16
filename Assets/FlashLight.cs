using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : Interactable
{
   
    protected override void Interact()
    {
        base.Interact();
        Debug.Log("Flash Light triggered");
    }
}
