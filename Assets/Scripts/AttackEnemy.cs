using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    private Animator anim;
    public float clickCooldown = 2f;
    private float nextAllowedClickTime = 0f;
    public float weaponDamage;
    private BoxCollider attackCol;

    private void Start()
    {
        anim = GetComponent<Animator>();
        attackCol = GetComponent<BoxCollider>();
    }


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
        if (Input.GetMouseButtonDown(0) && Time.time >= nextAllowedClickTime)
        {
            StartCoroutine(Swing());
        }
            
    }
}
//flourish by frankie