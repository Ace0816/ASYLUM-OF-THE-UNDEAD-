using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    private Animator anim;
    // Cooldown time between clicks (attacks), in seconds.
    public float clickCooldown = 2f;
    // Tracks when the player can next perform a click (attack)
    private float nextAllowedClickTime = 0f;
    // Damage dealt by the weapon (can be used for health reduction logic elsewhere).
    public float weaponDamage;
    // Reference to the BoxCollider used to detect hits during the attack animation.
    private BoxCollider attackCol;

    private void Start()
    {
        // Get and store reference to the Animator component.
        anim = GetComponent<Animator>();
        // Get and store reference to the BoxCollider component.
        attackCol = GetComponent<BoxCollider>();
    }

    // Coroutine that handles the attack animation and hit detection window.
    private IEnumerator Swing()
    {
        //adds a delay to how often you can click the mouse and trigger the animation
        //this coroutine was bought to you by Angelo
        {
            nextAllowedClickTime = Time.time + clickCooldown;
            attackCol.enabled = true;
            anim.Play("Swing", 0, 0f);
            yield return new WaitForSeconds(0.8f);
            attackCol.enabled = false;
        }
    }

    private void Update()
    {
        // Check if the left mouse button is pressed and if the cooldown has passed.
        if (Input.GetMouseButtonDown(0) && Time.time >= nextAllowedClickTime)
        {
            // Start the Swing coroutine to perform the attack.
            StartCoroutine(Swing());
        }
            
    }
}
//flourish by frankie