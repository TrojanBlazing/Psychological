using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class References : MonoBehaviour
{
    public static References Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public List<Canvas> canvasList = new List<Canvas>();

    [SerializeField] GameObject MasterSlider;
        [SerializeField] GameObject AmbienceSlider;
        [SerializeField] GameObject MusicSlider;
    [SerializeField] GameObject SFXSlider;
    AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.instance;
        UpdateAudioValues();
    }

    void UpdateAudioValues()
    {
   
                MasterSlider.GetComponent<Slider>().value = audioManager.masterVolume;
            
         
               MusicSlider.GetComponent<Slider>().value = audioManager.musicVolume;
            
           
               AmbienceSlider.GetComponent<Slider>().value = audioManager.ambienceVolume;
            
           
               SFXSlider.GetComponent<Slider>().value = audioManager.SFXVolume;
            
        }
    }

