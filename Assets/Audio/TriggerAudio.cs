using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    [SerializeField] GameObject AudioTriggerLocation;

    [SerializeField] RandomSFX randomSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.SetRandomSFX(randomSFX);
        }
    }
}
