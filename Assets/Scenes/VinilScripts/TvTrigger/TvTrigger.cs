using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvTrigger : MonoBehaviour
{
    public GameObject player;
   // public AudioSource am;
    void Start()
    {
        player.SetActive(false);
    }


 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.SetActive(true);
           // am.Play();

        }
    }
}
