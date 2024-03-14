using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareWindow : MonoBehaviour
{
     [SerializeField] private Animator ghostAnimator;

    [SerializeField] private GameObject gm;

    private bool hasPlayed = false;

   // public AudioClip jumpscareSound;
    private void Start()
    {
        gm.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            
            ghostAnimator.SetTrigger("Activate");

            // AudioSource.PlayClipAtPoint(jumpscareSound, transform.position);
            AudioManager.am.PlaySound("WIndowJumpScare");

            hasPlayed = true;
        }
    }


}
