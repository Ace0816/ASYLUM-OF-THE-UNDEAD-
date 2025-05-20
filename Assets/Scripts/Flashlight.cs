using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light Spotlight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("shift key pressed!");

            if(Spotlight != null)
            {
                Spotlight.enabled = !Spotlight.enabled;
                Debug.Log("spotlight toggled: " + Spotlight.enabled);
            }
            else
            {
                Debug.LogWarning("Target light not assigned");
            }
        }
    }
}
