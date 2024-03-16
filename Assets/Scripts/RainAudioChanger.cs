using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainAudioChanger : MonoBehaviour
{
    [SerializeField] BaseRainScript baseRainScript;
    [SerializeField] Door MainDoor;
    private void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            baseRainScript.RainIntensity = 0.2f;
           LockMainDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            baseRainScript.RainIntensity = 0.9f;
        }
    }
     void LockMainDoor()
    {
        
       MainDoor.LockDoor();
       
    }
}
