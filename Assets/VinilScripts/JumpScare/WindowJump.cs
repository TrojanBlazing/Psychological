using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowJump : MonoBehaviour
{


    public Transform targetPosition;   
    public float movementSpeed = 10f;  

    private bool triggered = false;    

    void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            StartJumpScare();
        }
    }

    void StartJumpScare()
    {
        if (targetPosition == null)
        {
            Debug.LogWarning("Target position i");
            return;
        }

       
        float distance = Vector3.Distance(transform.position, targetPosition.position);
        float timeToReach = distance / movementSpeed;

       
        StartCoroutine(MoveToTargetPosition(timeToReach));
    }

    IEnumerator MoveToTargetPosition(float timeToReach)
    {
        float elapsedTime = 0f;
        Vector3 startingPos = transform.position;
        Vector3 targetPos = targetPosition.position;

        while (elapsedTime < timeToReach)
        {
            transform.position = Vector3.Lerp(startingPos, targetPos, (elapsedTime / timeToReach));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

       
        transform.position = targetPos;


        
        gameObject.SetActive(false);
    }
}

