
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleController : MonoBehaviour
{
    [SerializeField]
    private GameObject dustParticle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dustParticle.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            dustParticle.SetActive(false);
        }
    }
}
