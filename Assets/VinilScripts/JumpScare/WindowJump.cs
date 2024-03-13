using UnityEngine;
using System.Collections;

public class WindowJump : MonoBehaviour
{
    public GameObject ghostObject;
    public Transform startPoint;
    public Transform endPoint;
    public float duration = 1f;

    private void Start()
    {
        ghostObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MoveGhost());
            GetComponent<Collider>().enabled = false;
        }

        IEnumerator MoveGhost()
        {
            ghostObject.SetActive(true);
            ghostObject.transform.position = startPoint.position;

            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                ghostObject.transform.position = Vector3.Lerp(startPoint.position, endPoint.position, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            ghostObject.transform.position = endPoint.position;
            ghostObject.SetActive(false);
        }
    }
}

