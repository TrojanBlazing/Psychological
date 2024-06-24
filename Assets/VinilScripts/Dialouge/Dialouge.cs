using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Dialouge : MonoBehaviour
{
    
   
    [SerializeField]
    GameObject NextSequenceTrigger;
    [SerializeField]
    private GameObject text;
    [SerializeField] private string dialouge;

    [SerializeField] private float timer = 5f;

    [SerializeField] DialoguesList dialogueNumber;
    [SerializeField] bool destroyGameObjectAtEnd;
    private void Start()
    {
        text.SetActive(false);

       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
           
            NextSequenceTrigger.SetActive(true);
            StartCoroutine(TextDisable());
        }
    }
    internal void TriggerDialogue()
    {
            text.GetComponent<TextMeshProUGUI>().text = dialouge;
            text.SetActive(true);
            AudioManager.instance.SetDiaolgue(dialogueNumber);
        if (NextSequenceTrigger != null)
        {
            NextSequenceTrigger.SetActive(true);
        }
            StartCoroutine(TextDisable());
           
        }
    
    IEnumerator TextDisable()
    {
        yield return new WaitForSeconds(timer);
        text.SetActive(false);

        if (destroyGameObjectAtEnd)
        {
            Destroy(this.gameObject);
        }
    }

}
