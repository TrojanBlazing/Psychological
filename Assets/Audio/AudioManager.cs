using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;
using FMODUnity;
using FMOD;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
   

    List<EventInstance> eventInstances;
    [SerializeField] GameObject Player;
    EventInstance ambienceInstance;
    EventInstance musicInstance;
    EventInstance dialogueInstance;
    public static AudioManager instance { get; private set; }
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        eventInstances = new List<EventInstance>();
      
    }
    private void Start()
    {
        //CreateAmbienceInstance(FmodEvents.instance.Ambience);
        //CreateMusicInstance(FmodEvents.instance.Music);
        CreateDialogueInstance(FmodEvents.instance.Dialogue);
    }

    public void PlayOneShotOnPlayer(EventReference sound) 
    {
    RuntimeManager.PlayOneShot(sound , Player.transform.position);
    }
    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
      
    }

    void CreateAmbienceInstance(EventReference ambience)
    {
        ambienceInstance = CreateEventInstance(ambience);
        ambienceInstance.start();
    }

    void CreateDialogueInstance(EventReference dialogue)
    {
        dialogueInstance = CreateEventInstance(dialogue);
       // dialogueInstance.start();
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