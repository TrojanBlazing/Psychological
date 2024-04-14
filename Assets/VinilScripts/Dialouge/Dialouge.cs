using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Dialouge : MonoBehaviour
{
    
    [SerializeField]
    private AudioSource am;

    [SerializeField]
    private GameObject text;
    //[SerializeField] private string dialouge = "Let me Check on Varun";

    [SerializeField] private float timer = 3f;

    [SerializeField] GameObject BabySnoreTrigger;
    private void Start()
    {
        text.SetActive(false);

       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        text.SetActive(true);
        am.Play();
        StartCoroutine(TextDisable());
    }
    internal void TriggerDialogue()
    {
       
            text.SetActive(true);
            am.Play();
            StartCoroutine(TextDisable());
           
        }
    
    IEnumerator TextDisable()
    {
        yield return new WaitForSeconds(timer);
        text.SetActive(false);
        if (BabySnoreTrigger != null)
        {
            BabySnoreTrigger.SetActive(true);
        }
        Destroy(this.gameObject); 
    }

}
