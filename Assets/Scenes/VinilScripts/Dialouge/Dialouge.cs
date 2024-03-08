using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialouge : MonoBehaviour
{
    [SerializeField]
    private GameObject Act;

    [SerializeField]
    private GameObject text;
    public string dialouge = "Let me Check on Varun";

    public float timer = 3f;

    private void Start()
    {
        text.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {

            text.SetActive(true);
           
            StartCoroutine(TextDisable());
           
        }
    }
    IEnumerator TextDisable()
    {
        yield return new WaitForSeconds(timer);
        text.SetActive(false);
        Destroy( Act ); 
    }

}
