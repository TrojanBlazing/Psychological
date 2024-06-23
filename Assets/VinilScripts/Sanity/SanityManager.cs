using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Events;
using TMPro;


public class SanityManager : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    [SerializeField]
    private int FullSanity;
    [SerializeField]
    private float doublediff;
    [SerializeField]
    private Volume vol;
     Vignette vig;
    private float percent;

    [SerializeField]
     private UnityEvent eve ;
    
    void Start()
    {
        vol.profile.TryGet<Vignette>(out vig);
        slider.GetComponent<Slider>();
        slider.maxValue=FullSanity;
        slider.value = FullSanity;
        StartCoroutine(Losingsanity());
        vig.intensity.value = 0;
    }
    IEnumerator Losingsanity()
    {
        while(slider.value>0)
        {
            slider.value -=  doublediff;
            float newVal = (slider.value - slider.maxValue) * -1f;
            percent = newVal / slider.maxValue;
            vig.intensity.value = percent;  
            yield return null;
        }
        eve.Invoke();
       
    }
    public void SanityEffect(float value)
    {
        slider.value += value;
    }

   
}
