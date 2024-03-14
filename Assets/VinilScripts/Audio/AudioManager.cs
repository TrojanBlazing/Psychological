using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager am;

    [SerializeField]
    private Sound[] sfx;
    [SerializeField]
    private AudioSource sfxsource;


    private void Awake()
    {
        if(am==null)
        {
            am = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sfx, x => x.Name == name);

        if(s==null)
        {
            Debug.Log("Sound not there");
        }
        else
        {
            sfxsource.PlayOneShot(s.clip);
        }
    }
}
