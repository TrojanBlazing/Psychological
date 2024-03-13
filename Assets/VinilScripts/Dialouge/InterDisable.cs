using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterDisable : MonoBehaviour
{
    [SerializeField]
    private GameObject door;

    [SerializeField]
    private GameObject Window;

    [SerializeField]
    private GameObject Act;

   // [SerializeField]
    //private AudioSource am;

    [SerializeField]
    private GameObject text;
    public string dialouge = "Yea hes asleep";

    public float timer = 3f;

    private void Start()
    {
        text.SetActive(false);
        door.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            text.SetActive(true);
             //am.Play();
            AudioManager.am.PlaySound("Snore");
            door.gameObject.SetActive(true);
            Window.gameObject.SetActive(true);

            StartCoroutine(TextDisable());

        }
    }
    IEnumerator TextDisable()
    {
        yield return new WaitForSeconds(timer);
        text.SetActive(false);
        Destroy(Act);
    }

}
