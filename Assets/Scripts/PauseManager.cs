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
    [SerializeField] GameObject Settings;
    [SerializeField] GameObject MainPanel;
    public  static PauseManager instance { get; private set; }
    public bool isPaused;
    bool isSettingsActive;
    PlayerInputAction playerInput;

    // list of all the canvas present in the scene.
    // to sort the canava which is in use at present
     List<Canvas> canvasList = new List<Canvas>();


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


    //canvas sorting order
    public void SetCanvasSortingOrder(Canvas targetCanvas, int highOrder = 10)
    {
        canvasList = References.Instance.canvasList;
        foreach (Canvas canvas in canvasList)
        {
            if (canvas == targetCanvas)
            {
                canvas.sortingOrder = highOrder;
            }
            else
            {
                canvas.sortingOrder = 0;
            }
        }
    }

    void PauseToggle(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            if(isSettingsActive)
            {
                OnReturnCalled();
            }
            else
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
            SetCanvasSortingOrder(PauseCanvas.GetComponent<Canvas>(),10);
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

    public void OnSettingsOpen()
    {
        MainPanel.SetActive(false);
        Settings.SetActive(true);
        isSettingsActive = true;
        SetCanvasSortingOrder(Settings.GetComponent<Canvas>(), 10);  //  get the settings canvas in front

    }

    public void OnReturnCalled()
    {
        SetCanvasSortingOrder(PauseCanvas.GetComponent<Canvas>(), 10); // get the pause menu canvas in front
        Settings.SetActive(false);
        isSettingsActive = false;
        MainPanel.SetActive(true);
    }
}
