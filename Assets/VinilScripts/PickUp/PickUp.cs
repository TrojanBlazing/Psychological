using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{    
   [SerializeField] private GameObject pickupText;
 [SerializeField] private GameObject LightOn;
    void Start()
    {
        LightOn.SetActive(false);
        pickupText.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickupText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                LightOn.SetActive(true);
                pickupText.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        pickupText.SetActive(false);
    }
}




