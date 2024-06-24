using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSleepingTriggerEvents : MonoBehaviour
{
    //Player sits
    //watches tv for 10 seconds
    // clock chimes
    // dialogue triggered 
    // goes to sleep
    //next scene triggered
    EventInstance clockChimes;
    [SerializeField] GameObject Clock;
    [SerializeField] Animator animator;
    private void Start()
    {
        Invoke("TriggerNextSequence" , 10);
    }

    void TriggerNextSequence()
    {
        Debug.Log("Clock Ding");
        //clockChimes = AudioManager.instance.CreateEventInstance(FmodEvents.instance.Rain);
        // AudioManager.instance.PlayOneShot(clockChimes,Clock.transform.position);
        animator.enabled = true;

        Invoke("SceneTransition", 11f);

    }

    void SceneTransition()
    {
        SceneController.instance.NextLevel();
    }
}
