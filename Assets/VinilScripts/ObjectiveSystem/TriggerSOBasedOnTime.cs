using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSOBasedOnTime : MonoBehaviour
{

    float gameTime;
    [SerializeField] float endTime;
    //[SerializeField] float EventNum;
    [SerializeField]
    private TextMeshProUGUI notiTextUI;
    [SerializeField]
    private Image CharIconUi;

    [SerializeField]
    private NotificationScriptable notificationScriptable;

    [SerializeField]
    private Animator notianim;

    private BoxCollider objectcollider;
    bool stopTimer;
    private void Awake()
    {
        objectcollider = gameObject.GetComponent<BoxCollider>();
        stopTimer = true;
    }

    public void TriggerStopTimer()
    {
        stopTimer = false;
    }
    private void Update()
    {
        Debug.Log(gameTime);
        Debug.Log(stopTimer);
        if(gameTime >endTime)
        {
            
            EnableNotification();
            stopTimer = true;
            gameTime = (int)gameTime;
        }
        if (!stopTimer)
        {
            gameTime += Time.deltaTime;
        }
    }

    void EnableNotification()
    {
        AudioManager.instance.PlayOneShotOnPlayer(FmodEvents.instance.ObjectiveSFX);
        notianim.Play("FadeIn");
        notiTextUI.text = notificationScriptable.NotificationMessage;
        CharIconUi.sprite = notificationScriptable.urIcon;

        Invoke(nameof(RemoveNotification), notificationScriptable.DisableTimer);

        Invoke(nameof(TriggerDialogueWithDelay), 4f);
    }
    void TriggerDialogueWithDelay()
    {
        gameObject.GetComponent<Dialouge>().TriggerDialogue();
    }
    private void RemoveNotification()
    {
        notianim.Play("FadeOut");
    }
}
