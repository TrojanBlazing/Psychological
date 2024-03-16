using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : Interactable
{
    [SerializeField] GameObject lights;
    bool lightsOn;

    private void Awake()
    {
        lightsOn = true;
    }
    internal void ToggleLights()
    {
        if(lightsOn)
        {
            lights.SetActive(false);
            lightsOn = false;
        }
        else if(!lightsOn) 
        {
            lights.SetActive(true);
            lightsOn = true;
        }

    }

    protected override void Interact()
    {
        base.Interact();
        if (lightsOn)
        {
            lights.SetActive(false);
            lightsOn = false;
        }
        else if (!lightsOn)
        {
            lights.SetActive(true);
            lightsOn = true;
        }
    }
}
