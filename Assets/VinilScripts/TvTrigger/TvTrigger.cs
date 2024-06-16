using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvTrigger : MonoBehaviour
{
    [SerializeField] private GameObject TV;
 
    [SerializeField] private GameObject trigger;
    void Start()
    {
        TV.SetActive(false);
        trigger.SetActive(false);
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TV.SetActive(true);
            trigger.SetActive(true);
          

        }
    }
}
