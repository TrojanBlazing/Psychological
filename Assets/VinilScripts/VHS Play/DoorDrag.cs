using UnityEngine;
using System.Collections;

public class DoorDrag : MonoBehaviour
{
    public float ySensitivity = 20f; 
    public float frontOpenPosLimit = 90;
    public float backOpenPosLimit = 90;

    public GameObject frontDoorCollider;
    public GameObject backDoorCollider;

    bool moveDoor = false;
    DoorCollision doorCollision = DoorCollision.NONE;

    void Start()
    {
        StartCoroutine(doorMover());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse down");

            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                if (hitInfo.collider.gameObject == frontDoorCollider)
                {
                    moveDoor = true;
                    Debug.Log("Front door hit");
                    doorCollision = DoorCollision.FRONT;
                }
                else if (hitInfo.collider.gameObject == backDoorCollider)
                {
                    moveDoor = true;
                    Debug.Log("Back door hit");
                    doorCollision = DoorCollision.BACK;
                }
                else
                {
                    doorCollision = DoorCollision.NONE;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            moveDoor = false;
            Debug.Log("Mouse up");
        }
    }

    IEnumerator doorMover()
    {
        bool stoppedBefore = false;
        float targetRotation = 0;
        float currentRotation = 0;

        while (true)
        {
            if (moveDoor)
            {
                stoppedBefore = false;
                Debug.Log("Moving Door");

                float mouseY = Input.GetAxis("Mouse Y");
                float rotationDelta = mouseY * ySensitivity * Time.deltaTime;

                // Check if this is front door or back
                if (doorCollision == DoorCollision.FRONT)
                {
                    Debug.Log("Pull Down");
                    targetRotation += rotationDelta;
                    targetRotation = Mathf.Clamp(targetRotation, -frontOpenPosLimit, 0);
                    currentRotation = Mathf.Lerp(currentRotation, targetRotation, 0.5f); // Smoothly interpolate towards the target rotation
                    transform.localEulerAngles = new Vector3(0, -currentRotation, 0);
                }
                else if (doorCollision == DoorCollision.BACK)
                {
                    Debug.Log("Pull Up ");
                    targetRotation -= rotationDelta;
                    targetRotation = Mathf.Clamp(targetRotation, 0, backOpenPosLimit);
                    currentRotation = Mathf.Lerp(currentRotation, targetRotation, 0.5f); // Smoothly interpolate towards the target rotation
                    transform.localEulerAngles = new Vector3(0, currentRotation, 0);
                }
            }
            else
            {
                if (!stoppedBefore)
                {
                    stoppedBefore = true;
                    Debug.Log("Stopped Moving Door");
                }
            }

            yield return null;
        }
    }

    enum DoorCollision
    {
        NONE, FRONT, BACK
    }
}
