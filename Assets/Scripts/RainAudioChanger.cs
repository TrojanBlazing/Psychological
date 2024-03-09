using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainAudioChanger: MonoBehaviour
{
    [SerializeField] BaseRainScript baseRainScript;
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        baseRainScript.RainIntensity = 0.2f;
    }
}
