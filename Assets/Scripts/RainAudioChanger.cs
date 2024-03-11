using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainAudioChanger : MonoBehaviour
{
    [SerializeField] BaseRainScript baseRainScript;
    [SerializeField] Door mainDoor;
    private void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            baseRainScript.RainIntensity = 0.2f;
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            baseRainScript.RainIntensity = 0.9f;
        }
    }
    public void LockMainDoor()
    {
        mainDoor.MainDoorLocked();
    }
}
