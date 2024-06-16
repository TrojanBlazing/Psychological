using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI promptText;
   

    // Update is called once per frame
    public void UpdateText(string displayText)
    {
       
        promptText.text = displayText;
    }
}
