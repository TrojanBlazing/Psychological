using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    List<EventInstance> eventInstances;
    [SerializeField] GameObject Player;
    EventInstance ambienceInstance;
    EventInstance musicInstance;
    EventInstance dialogueInstance;
    EventInstance randomSFXInstance;
    public static AudioManager instance { get; private set; }

    [Header("Volume")]
    [Range(0, 1)]

    public float masterVolume = 1;
    [Range(0, 1)]
    public float musicVolume = 1;
    [Range(0, 1)]
    public float ambienceVolume = 1;
    [Range(0, 1)]
    public float SFXVolume = 1;

    internal Bus masterBus;
    Bus musicBus;
    Bus ambienceBus;
    Bus sfxBus;
    private void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        eventInstances = new List<EventInstance>();

        masterBus = RuntimeManager.GetBus("bus:/");
        musicBus = RuntimeManager.GetBus("bus:/Music");
        sfxBus = RuntimeManager.GetBus("bus:/SFX");
        ambienceBus = RuntimeManager.GetBus("bus:/Ambience");

        masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        ambienceVolume = PlayerPrefs.GetFloat("AmbienceVolume");
        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void UpdateMaster()
    { masterVolume = PlayerPrefs.GetFloat("MasterVolume"); masterBus.setVolume(masterVolume);}

    public void UpdateMusic() { musicVolume = PlayerPrefs.GetFloat("MusicVolume"); musicBus.setVolume(musicVolume); }

    public void UpdateAmbience() { ambienceVolume = PlayerPrefs.GetFloat("AmbienceVolume"); ambienceBus.setVolume(ambienceVolume); }

    public void UpdateSFX() { SFXVolume = PlayerPrefs.GetFloat("SFXVolume"); sfxBus.setVolume(SFXVolume); }
    private void Start()
    {
        
        CreateAmbienceInstance(FmodEvents.instance.Rain);
        //CreateMusicInstance(FmodEvents.instance.Music);
        CreateDialogueInstance(FmodEvents.instance.Dialogue);
        CreateRandomSFXInstance(FmodEvents.instance.RandomSFX);


        
    }
    public void PlayOneShotOnPlayer(EventReference sound) 
    {
        if (Player != null)
        {
            RuntimeManager.PlayOneShot(sound, Player.transform.position);
        }
    }
    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
      
    }

    void CreateAmbienceInstance(EventReference ambience)
    {
        ambienceInstance = CreateEventInstance(ambience);
        ambienceInstance.setParameterByName("Rain_Intensity" , 1);
        ambienceInstance.setParameterByName("RainDampness" , 1);
        ambienceInstance.start();
        
    }

    public void SetAmbienceParameter(string parameter, float value) 
    {
        
        ambienceInstance.setParameterByName(parameter, value);
        ambienceInstance.start();
    }

    void CreateDialogueInstance(EventReference dialogue)
    {
        dialogueInstance = CreateEventInstance(dialogue);
      
    }

    void CreateRandomSFXInstance(EventReference SFX)
    {
        randomSFXInstance = CreateEventInstance(SFX);
      
    }
    void CreateMusicInstance(EventReference music)
    {
        musicInstance= CreateEventInstance(music);
        musicInstance.start();
    }
    public EventInstance CreateEventInstance(EventReference eventReference) 
       {
           EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    public void SetRandomSFX(RandomSFX index)
    {
        randomSFXInstance.setParameterByName("RandomSFX",(float) index ); 
        randomSFXInstance.start();
    }
    public void SetDiaolgue(DialoguesList index)
    {
        dialogueInstance.setParameterByName("Dialogues" , (float)index);
        dialogueInstance.start();
    }
    
    void Cleanup()
    {

        foreach (EventInstance e in eventInstances)
        {
            e.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            e.release();
        } }

    private void OnDestroy()
    {
        Cleanup();
    }
}
