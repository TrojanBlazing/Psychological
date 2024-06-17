using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosttrigger : MonoBehaviour
{ 

public Animator playerAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            playerAnimator.SetTrigger("GhostInteraction");
        }
    }
}


