using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WakingUpScript : MonoBehaviour
{

    //Play audio
    //Show the objective
    [SerializeField] GameObject ExploreHouseTrigger;
    Interaction interaction;

    private void Start()
    {
        interaction = GetComponent<Interaction>();
    }
    internal void PerformAfterWakingAction()
    {
        //Play audio here then trigger objective
        //Debug.Log("Audio Played");
        //wait for the audio to finish then 
        Invoke("TriggerObjective" , 4);
       
        

    }

    void TriggerObjective()
    {
      ExploreHouseTrigger.GetComponent<TriggerScriptableObjective>().EnableNotification();
       interaction.enabled = true;
    }

 
    internal void PlayerInteracted() 
    {
        Destroy(this.gameObject);
    }

}
