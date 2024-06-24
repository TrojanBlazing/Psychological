using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareWindow : MonoBehaviour
{
    [SerializeField] GameObject doorGhost;
    [SerializeField] GameObject tvTrigger;
    private bool hasPlayed = false;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            doorGhost.SetActive(true);
            doorGhost.GetComponent<Animator>().SetTrigger("Activate");            
           
            hasPlayed = true;

           gameObject.GetComponent<Collider>().enabled = false;
            Invoke("DestroySelfAndGhost", 6f);
        }
    }

    void DestroySelfAndGhost()
    {
        Destroy(doorGhost);
        tvTrigger.SetActive(true);
        Destroy(this.gameObject);
    }
}
