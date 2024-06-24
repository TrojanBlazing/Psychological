using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvTrigger : MonoBehaviour
{
    [SerializeField] private GameObject TV;
 
  

    

    internal bool isTriggered;
    void Start()
    {
        TV.SetActive(false);
       
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TV.SetActive(true);
           
           
            isTriggered = true;
           
        }
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
