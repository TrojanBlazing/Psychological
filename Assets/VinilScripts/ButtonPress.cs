using UnityEngine;

public class RapidButtonPress : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.Space;
    public int pressCountNeeded = 10; 
    public float timeBetweenPresses = 0.2f; 

    public Animator doorAnimator; 
    public bool doorOpen = false; 

    private int currentPressCount = 0;
    private float lastPressTime = 0f;
    private bool isPressing = false;

    private void Update()
    {
        
        if (doorOpen)
            return;

        
        if (Input.GetKeyDown(interactKey))
        {
           
            if (!isPressing || Time.time - lastPressTime > timeBetweenPresses)
            {
                currentPressCount++;
                lastPressTime = Time.time;
                isPressing = true;

                
                if (currentPressCount >= pressCountNeeded)
                {
                    OpenDoor(); 
                }
            }
        }

       
        if (Input.GetKeyUp(interactKey))
        {
           // currentPressCount = 0;
            isPressing = false;
        }
    }

    private void OpenDoor()
    {
        Debug.Log("Door opened!");
        
        doorOpen = true;

       
        doorAnimator.SetBool("Open", doorOpen);

       
    }
}
