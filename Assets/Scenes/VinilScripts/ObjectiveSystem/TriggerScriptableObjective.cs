using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TriggerScriptableObjective : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI notiTextUI;
    [SerializeField]
    private Image CharIconUi;

    [SerializeField]
    private NotificationScriptable notificationScriptable;

    [SerializeField]
    private Animator notianim;

    private BoxCollider objectcollider;


    [SerializeField] private AudioSource am;

    [SerializeField] private AudioClip notificationSound;

    private void Awake()
    {
        objectcollider = gameObject.GetComponent<BoxCollider>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableNotification();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && notificationScriptable.removeAfterExit)
        {
            RemoveNotification();
        }
    }

    void EnableNotification()
    {
        objectcollider.enabled = false;
        notianim.Play("FadeIn");
        notiTextUI.text = notificationScriptable.NotificationMessage;
        CharIconUi.sprite = notificationScriptable.urIcon;

        if (notificationSound != null && am != null)
        {
            am.clip = notificationSound;
            am.Play();
        }
        Invoke(nameof(RemoveNotification), notificationScriptable.DisableTimer);
    }
    private void RemoveNotification()
    {
        notianim.Play("FadeOut");
    }
}
