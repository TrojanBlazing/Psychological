using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlashController : MonoBehaviour
{
    [SerializeField] private Light flashLight;
    [SerializeField] private float flashDuration = 0.1f;
    [SerializeField] private float flashCooldown = 2.0f;
    [SerializeField] private float detectionRange = 5f; 
    [SerializeField] private KeyCode flashKey = KeyCode.F;
    private bool isFlashing = false;
    private bool canFlash = true;

    private List<GameObject> flashObjects;

    void Start()
    {
        flashObjects = new List<GameObject>();

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("FlashReveal"))
        {
            flashObjects.Add(obj);
            obj.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(flashKey) && canFlash)
        {
            StartCoroutine(Flash());
        }
    }

    IEnumerator Flash()
    {
        isFlashing = true;
        canFlash = false;
        flashLight.enabled = true;

        Debug.Log("Flash started");

        foreach (GameObject obj in flashObjects)
        {
           
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance <= detectionRange)
            {
               
                obj.SetActive(true);
            }
        }

        yield return new WaitForSeconds(flashDuration);

        flashLight.enabled = false;

        foreach (GameObject obj in flashObjects)
        {
            
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance <= detectionRange)
            {
               
                obj.SetActive(false);
            }
        }

        Debug.Log("Flash ended");

        isFlashing = false;

        yield return new WaitForSeconds(flashCooldown);
        canFlash = true;
    }
}
