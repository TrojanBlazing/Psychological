using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{

    /*For pause we need to: 
    1. stop the player input and enemy ai
    2. pause the audio 
    3. if anything more update here
        */

    [SerializeField] GameObject PauseCanvas;
    public  static PauseManager instance { get; private set; }
    public bool isPaused;
    PlayerInputAction playerInput;
 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }
    private void Start()
    {
        playerInput = new PlayerInputAction();
        playerInput.PlayerMovement.Enable();
        playerInput.PauseHandle.Disable();
        playerInput.PlayerMovement.Pause.performed += PauseToggle;
        playerInput.PauseHandle.TogglePause.performed += PauseToggle;
    }

    void PauseToggle(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            OnResumeCalled();
        }
        else
        {   
            OnPauseCalled();
        }
    }
    public void OnPauseCalled()
    {
        if(!isPaused)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            PauseCanvas.SetActive(true);
            PauseCanvas.GetComponent<Canvas>().sortingOrder = 2;
            AudioManager.instance.masterBus.setPaused(true);
            playerInput.PlayerMovement.Disable();
            playerInput.PauseHandle.Enable();
            Time.timeScale = 0;
            isPaused = true;
        }

    }

    public void OnResumeCalled() {

       
        PauseCanvas.GetComponent<Canvas>().sortingOrder = 0;
        PauseCanvas.SetActive(false);
        Time.timeScale = 1;
        AudioManager.instance.masterBus.setPaused(false);
        playerInput.PlayerMovement.Enable();
        playerInput.PauseHandle.Disable();
        isPaused = false;
    }
}
