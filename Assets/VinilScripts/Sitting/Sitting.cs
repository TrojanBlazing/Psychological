using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sitting : Interactable
{
    [SerializeField] GameObject playerStand;
    [SerializeField] GameObject playerSit;
    [SerializeField] GameObject playerSitStory;
    [SerializeField] TextMeshProUGUI sofaInteractText;
    bool IsSitting = true;
    bool IsInteract;

    [SerializeField] TvTrigger tvTrigger;

    PlayerInputAction pa;
    private InputAction interactAction;
    private void SitDown()
    {

        if (tvTrigger == null)
        {
            playerSit.SetActive(true);
        }

        else if(tvTrigger.isTriggered) 
        {
           playerSitStory.SetActive(true);
            tvTrigger.DestroySelf();
        }
        IsSitting = true;
        playerStand.SetActive(false);
    }

    private void StandUp()
    {

       
         playerSit.SetActive(false);
        
        playerStand.SetActive(true);
        IsSitting = false;
    }

    protected override void Interact()
    {
        base.Interact();
        if (!IsSitting)
        {
            SitDown();
        }
        else if (IsSitting)
        {
            StandUp();
        }


    }
}
