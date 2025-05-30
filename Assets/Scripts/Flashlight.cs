using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    // Reference to the Light component that acts as the flashlight spotlight
    public Light Spotlight;
    // Tracks the current state of the flashlight (on/off)
    private bool lightOn;

    // Called when the script instance is being loaded
    private void Start()
    {
        // Start coroutine to automatically turn off the light after 5 seconds
        StartCoroutine(TurnOffLightAfterDelay(5f));
        // If Spotlight is not assigned in the inspector, try to find a Light component in children
        if (Spotlight == null)
        {
            Spotlight = GetComponentInChildren<Light>();
        }
    }

    private void Update()
    {
        // Check if the Left Shift key was pressed down this frame
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ToggleLight();
        }
    }

    // Toggles the spotlight's enabled state
    public void ToggleLight()
    {
        // Switch the light's enabled state (on if off, off if on)
        Spotlight.enabled = !Spotlight.enabled;

        if (Spotlight.enabled)
        {
            // If light is turned on, ensure it's enabled and start coroutine to turn off after delay
            Spotlight.enabled = true;
            StartCoroutine(TurnOffLightAfterDelay(5f));
        }
        else
        {
            // If light is turned off, disable it
            Spotlight.enabled = false;
        }
    }

    // Coroutine that waits for the specified delay before turning off the light
    IEnumerator TurnOffLightAfterDelay(float delay)
    {
        // Wait for the delay time in seconds
        yield return new WaitForSeconds(delay);
        Spotlight.enabled = false;
    }
}
