using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBasedEvents : MonoBehaviour
{
   

    [SerializeField] float gameTime; // Time elapsed in the game
    [SerializeField] float resetTime = 60f; // Time to reset in seconds (default: 120 seconds)

    private bool isTimeResetting = false; // Flag to indicate if time reset is in progress

    void Update()
    {
        if (!isTimeResetting)
        {
            gameTime += Time.deltaTime; // Increment game time
        }

        // Check if it's time to reset
        if (gameTime >= resetTime)
        {
            ResetTime();
        }

       //  Debug.Log(gameTime);
    }

    void ResetTime()
    {
        // Add your code here for resetting time or triggering events
        // For example, you can reset the game time and trigger a scare event

        // Reset game time
        gameTime = 0f;

        // Set flag to prevent multiple resets at once
        isTimeResetting = true;

        // Add any additional reset logic here

        // Reset the flag after a delay (e.g., 3 seconds)
        Invoke("ResetFlag", 2f);
    }

    void ResetFlag()
    {
        isTimeResetting = false;
    }
}
