using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageFlash : MonoBehaviour
{
    public Image damageOverlay; // Assign in Inspector
    public float flashDuration = 0.5f;
    public Color flashColor = new Color(1, 0, 0, 0.5f); // Semi-transparent red

    private float flashTimer;
    private Color originalColor;

    void Start()
    {
        if (damageOverlay != null)
        {
            originalColor = damageOverlay.color;
            damageOverlay.color = originalColor;
        }
    }

    void Update()
    {
        if (flashTimer > 0)
        {
            flashTimer -= Time.deltaTime;
            damageOverlay.color = Color.Lerp(originalColor, flashColor, flashTimer / flashDuration);
        }
        else if (damageOverlay.color != originalColor)
        {
            damageOverlay.color = originalColor;
        }
    }

    public void TriggerFlash()
    {
        flashTimer = flashDuration;
        damageOverlay.color = flashColor;
    }
}
