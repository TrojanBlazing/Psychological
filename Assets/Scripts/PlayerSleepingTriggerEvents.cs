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

    [SerializeField] FadingScript fadingScript;
    [SerializeField] GameObject PromptTest;
    private void Start()
    {
        PromptTest.SetActive(false);
        StartCoroutine(TriggerSequence());
    }


    IEnumerator TriggerSequence()
    {
        yield return new WaitForSeconds(10);
        AudioManager.instance.PlayOneShot(FmodEvents.instance.Clock, transform.position);

        yield return new WaitForSeconds(3);
        gameObject.GetComponent<Dialouge>().TriggerDialogue();

        yield return new WaitForSeconds(3);
        animator.enabled = true;

        yield return new WaitForSeconds(11f);
        fadingScript.FadeOut();

        yield return new WaitForSeconds(5);
        SceneController.instance.NextLevel();

    }
  
}
