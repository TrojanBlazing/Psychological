using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;
   // public AudioSource am;

    [SerializeField] private GameObject trigger;
    void Start()
    {
        player.SetActive(false);
        trigger.SetActive(false);
    }


 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.SetActive(true);
            trigger.SetActive(true);
           // am.Play();

        }
    }
}
