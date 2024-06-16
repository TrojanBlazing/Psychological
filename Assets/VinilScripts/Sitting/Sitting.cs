using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sitting : Interactable
{
    [SerializeField] GameObject playerStand;
    [SerializeField] GameObject playerSit;
    [SerializeField] TextMeshProUGUI sofaInteractText;
    [SerializeField] string sitTextString;
    [SerializeField] string standTextString;

    [SerializeField] float interactionDistance = 3f; 

    bool IsSitting;
    bool IsInteract;

    PlayerInputAction pa;
    private InputAction interactAction;

  /*  private void Awake()
    {
       // pa = new PlayerInputAction();
    }*/

    /*private void OnEnable()
    {
        pa.PlayerMovement.Enable();
        interactAction = pa.PlayerMovement.Interact;

        interactAction.performed += OnInteractPerformed;
    }

    private void OnDisable()
    {
        interactAction.performed -= OnInteractPerformed;
        pa.PlayerMovement.Disable();
    }*/

   /* void Update()
    {
        //RaycastForInteraction();
        //SitOrStand();
    }
*/
    private void RaycastForInteraction()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("Sittable"))
            {
                sofaInteractText.text = sitTextString;
                IsInteract = true;
            }
        }
        else
        {
            sofaInteractText.text = string.Empty;
            IsInteract = false;
        }
    }

  /*  private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        if (IsInteract && !IsSitting)
        {
            SitDown();
        }
        else if (IsSitting)
        {
            StandUp();
        }
    }*/

    private void SitOrStand()
    {
        if (IsSitting)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                StandUp();
            }
        }
    }

    private void SitDown()
    {
       // sofaInteractText.text = standTextString;
        playerSit.SetActive(true);
        IsSitting = true;
        playerStand.SetActive(false);
    }

    private void StandUp()
    {
       // sofaInteractText.text = sitTextString;
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
