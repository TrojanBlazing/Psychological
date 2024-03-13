using UnityEngine;

public class CamerasZoomOut : MonoBehaviour
{
    public Transform cubeToZoomOutFrom;
    public float zoomSpeed = 2.0f;
    public float minDistance = 2.0f;
    public float maxDistance = 10.0f;
    public float stopDistance = 5.0f;





    private Vector3 initialPosition;
    private Camera cam;

    void Start()
    {

        cam = GetComponent<Camera>();
        initialPosition = transform.position;
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

    }
}
