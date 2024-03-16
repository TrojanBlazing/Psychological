using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sitting : MonoBehaviour
{
    [SerializeField] GameObject playerStand;
    [SerializeField] GameObject playerSit;
    [SerializeField] TextMeshProUGUI sofaInteractText;
   // [SerializeField] TextMeshProUGUI standText;
    [SerializeField] string sitTextString;
    [SerializeField] string standTextString;
    bool IsSitting;
    bool IsInteract;

    void Update()
    {
        Sit();
    }
    private void Start()
    {
       sofaInteractText.text = string.Empty;
       // standText.text = string.Empty;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            sofaInteractText.text = sitTextString;
            IsInteract = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            sofaInteractText.text = string.Empty;
            IsInteract = false;
        }
    }

    private void Sit()
    {
        if (IsInteract == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                sofaInteractText.text = standTextString;
                //standText.text = standTextString;
                playerSit.SetActive(true);
                IsSitting = true;
                playerStand.SetActive(false);
                IsInteract = false;
            }
        }

        if (IsSitting == true)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
               // standText.text = string.Empty;
                playerSit.SetActive(false);
                playerStand.SetActive(true);
                IsSitting = false;
            }
        }
    }
}
