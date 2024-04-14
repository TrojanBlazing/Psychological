using UnityEngine;
using System.Collections;

public class WindowJump : MonoBehaviour
{
    [SerializeField] GameObject ghostObject;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] float duration = 3f;

   
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
            ghostObject.GetComponent<AudioSource>().Play();
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
        Invoke(nameof(DestroySelf),4f);
         
    }

    void DestroySelf()
    {
        Destroy(this.gameObject.GetComponentInParent<Transform>().gameObject);
    }
}

