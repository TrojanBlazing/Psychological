using UnityEngine.SceneManagement;
using UnityEngine;

using System.Collections;

public class CamerasZoomOut : MonoBehaviour
{
    [SerializeField] Transform cubeToZoomOutFrom;
    [SerializeField] float zoomSpeed = 2.0f;
    [SerializeField] float minDistance = 2.0f;
    [SerializeField] float maxDistance = 10.0f;
    [SerializeField] float stopDistance = 5.0f;
  
    private Vector3 initialPosition;
   

    void Start()
    {
       
        //initialPosition = transform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, cubeToZoomOutFrom.position);
        float desiredDistance = Mathf.Lerp(minDistance, maxDistance, distance / stopDistance);
        Vector3 directionToCube = (cubeToZoomOutFrom.position - transform.position).normalized;
        Vector3 desiredPosition = cubeToZoomOutFrom.position - directionToCube * desiredDistance;

        if (distance > stopDistance)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * zoomSpeed);
        }
         
            StartCoroutine(LoadNextScene());
        
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(5f); 
        SceneManager.LoadScene(3); 
        
    }
}
