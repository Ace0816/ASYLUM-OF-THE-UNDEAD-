using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageFlash : MonoBehaviour
{
    // UI Image that will be used as the damage flash overlay
    public Image damageOverlay; 
    public float flashDuration = 0.5f;
    public Color flashColor = new Color(1, 0, 0, 0.5f); 

    //Internal timer to track how long the flash should remain
    private float flashTimer;
    //orignial color of the overlay, to revert back to after the flash
    private Color originalColor;

    void Start()
    {
        //if a damage overlay image is assigned, store its original color
        if (damageOverlay != null)
        {
            originalColor = damageOverlay.color;
            damageOverlay.color = originalColor;
        }
    }

    void Update()
    {
        //If the flash is active (timer > 0), gradually blend the overlay back to its original color
        if (flashTimer > 0)
        {
            flashTimer -= Time.deltaTime;
            // Lerp from flashColor to originalColor over the flash duration
            damageOverlay.color = Color.Lerp(originalColor, flashColor, flashTimer / flashDuration);
        }
        // Once the flash is done, make sure the overlay is fully reset to its original color
        else if (damageOverlay.color != originalColor)
        {
            damageOverlay.color = originalColor;
        }
    }

    // Call this method to trigger the flash effect (e.g., when the player takes damage)
    public void TriggerFlash()
    {
        flashTimer = flashDuration; //reset the tier
        damageOverlay.color = flashColor; //set the flash color immediately
    }
}
