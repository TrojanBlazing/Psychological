using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareWindow : MonoBehaviour
{
     public Animator ghostAnimator;
   
    public GameObject gm;

    private bool hasPlayed = false;

    public AudioClip jumpscareSound;
    private void Start()
    {
        gm.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            
            ghostAnimator.SetTrigger("Activate");

            AudioSource.PlayClipAtPoint(jumpscareSound, transform.position);

            hasPlayed = true;
        }
    }


}
