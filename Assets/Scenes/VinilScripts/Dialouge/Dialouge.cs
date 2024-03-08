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
    private TextMeshProUGUI text;
    public string dialouge = "Let me Check on Varun";

    public float timer = 3f;

    private void Start()
    {
        text.GetComponent<TextMeshProUGUI>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            text.GetComponent<TextMeshProUGUI>().enabled = true;
            text.text = dialouge.ToString();
           // Destroy(Act);
        }
    }


}
