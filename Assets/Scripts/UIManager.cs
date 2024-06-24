using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    
    public void OnStartClick()
    {
        SceneController.instance.NextLevel();
    }

    public void OnSettingClick()
    {
        Debug.Log("Settings opened");
    }

    public void OnQuitClick()
    {
        Application.Quit();
       #if UNITY_EDITOR
        // Stop playing the scene
        EditorApplication.isPlaying = false;
       #endif
    }
}
