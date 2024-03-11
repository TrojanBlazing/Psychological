using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterOn : MonoBehaviour
{
    [SerializeField]
    private GameObject Lighter;

    [SerializeField]
    private GameObject ParticleFlame;

    private bool isOn;

    void Start()
    {
        isOn = false;
        ParticleFlame.SetActive(false);
    }

    void Update()
    {
        TurnOn();
    }

    private void TurnOn()
    {
        if (Input.GetKeyDown(KeyCode.E) && Lighter.activeInHierarchy && !isOn)
        {
            ParticleFlame.SetActive(true);
            isOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isOn)
        {
            ParticleFlame.SetActive(false);
            isOn = false;
        }
    }
}

