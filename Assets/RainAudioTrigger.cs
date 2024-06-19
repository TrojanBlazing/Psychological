using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainAudioTrigger : MonoBehaviour
{
    [SerializeField] string parameterNameForIntensity;
    [SerializeField] string parameterNameForDampness;
    [SerializeField] float parameterValueWhenEntered;
    [SerializeField] float parameterValueWhenExited;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
           
            AudioManager.instance.SetAmbienceParameter(parameterNameForIntensity, parameterValueWhenEntered);
            AudioManager.instance.SetAmbienceParameter(parameterNameForDampness , parameterValueWhenEntered);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            AudioManager.instance.SetAmbienceParameter(parameterNameForIntensity, parameterValueWhenExited);
            AudioManager.instance.SetAmbienceParameter(parameterNameForDampness, parameterValueWhenExited);
        }
    }
}
