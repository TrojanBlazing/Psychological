using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    // [SerializeField] float interactDistance = 3f; 
    [SerializeField] float openAngle = 90f;
    [SerializeField] float openSpeed = 2f;


    private Quaternion openRotation;
    private Quaternion closedRotation;
    private Quaternion targetRotation;

    bool moveDoor;

    void Start()
    {
        openRotation = Quaternion.Euler(0f, openAngle, 0f);
        closedRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void Update()
    {
        if (moveDoor)
        {

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, openSpeed * Time.deltaTime);
        }
    }
   
    public void LockDoor()
    {
        ToggleDoor();

    }
    public void ToggleDoor()
    {
        if (targetRotation == openRotation)
        {

            targetRotation = closedRotation;
        }
        else
        {

            targetRotation = openRotation;
        }
    }
    protected override void Interact()
    {
        base.Interact();
        ToggleDoor();
        moveDoor = true;
    }
}
