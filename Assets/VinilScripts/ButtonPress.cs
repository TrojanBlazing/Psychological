using UnityEngine.InputSystem;
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

    PlayerInputAction pa;
    private InputAction interactAction;

    private void Awake()
    {
        pa = new PlayerInputAction();
    }

    private void OnEnable()
    {
        pa.PlayerMovement.Enable();
        interactAction = pa.PlayerMovement.Interaction; 
        interactAction.performed += OnInteractPerformed;
        interactAction.canceled += OnInteractCanceled;
    }

    private void OnDisable()
    {
        interactAction.performed -= OnInteractPerformed;
        interactAction.canceled -= OnInteractCanceled;
        pa.PlayerMovement.Disable();
    }

    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        ProcessInteraction();
    }

    private void OnInteractCanceled(InputAction.CallbackContext context)
    {
        isPressing = false;
    }

    private void ProcessInteraction()
    {
        if (doorOpen)
            return;

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

    private void OpenDoor()
    {
        Debug.Log("Door opened!");
        doorOpen = true;
        doorAnimator.SetBool("Open", doorOpen);
    }
}
