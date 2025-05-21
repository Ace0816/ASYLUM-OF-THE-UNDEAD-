using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light Spotlight;
    private bool lightOn;

    private void Start()
    {
        StartCoroutine(TurnOffLightAfterDelay(5f));
        if (Spotlight == null)
        {
            Spotlight = GetComponentInChildren<Light>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ToggleLight();
        }
    }

    public void ToggleLight()
    {
        Spotlight.enabled = !Spotlight.enabled;

        if (Spotlight.enabled)
        {
            Spotlight.enabled = true;
            StartCoroutine(TurnOffLightAfterDelay(5f));
        }
        else
        {
            Spotlight.enabled = false;
        }
    }

    IEnumerator TurnOffLightAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Spotlight.enabled = false;
    }
}
