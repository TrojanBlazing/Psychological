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
    public bool Open { get; private set; }
    RaycastHit hit;
    public bool mainDoorLocked {  get; private set; }
    private void Start()
    {
        pcamera = Camera.main;
        text.SetActive(false);
    }

    /*private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
          PressCheck();
        }
    }*/
    public void PressCheck()
    {
                anim = hit.transform.GetComponentInParent<Animator>();
                Open = !Open;
                anim.SetBool("Open", !Open);
                
    }

    public void MainDoorLocked()
    {
        mainDoorLocked = true;
       
    }
    private void UpdateTextVisibility()
    {
        
        if (Physics.Raycast(pcamera.transform.position, pcamera.transform.forward, out hit, maxDistance))
        {
            if (hit.transform.tag == "Door" || hit.transform.tag =="MainDoor")
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
