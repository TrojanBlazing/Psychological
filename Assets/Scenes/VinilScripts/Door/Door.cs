using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
     private Camera pcamera;
    [SerializeField] private float maxDistance = 3;
    public GameObject text;
   
    private Animator anim;
    private bool open = false;
    RaycastHit hit;
    private void Start()
    {
        pcamera = Camera.main;
        text.SetActive(false);
    }
    public void PressCheck()
    {
                anim = hit.transform.GetComponentInParent<Animator>();
                open = !open;
                anim.SetBool("Open", !open);  
    }

    private void UpdateTextVisibility()
    {
        
        if (Physics.Raycast(pcamera.transform.position, pcamera.transform.forward, out hit, maxDistance))
        {
            if (hit.transform.tag == "Door")
            {
                text.SetActive(true);
                return;
            }
        }
        text.SetActive(false);
    }

    private void FixedUpdate()
    {
        UpdateTextVisibility();
    }
}
