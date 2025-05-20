using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    //weapon animation code
    private Animator anim;
    public float clickCooldown = 1f;
    private float nextAllowedClickTime = 0f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //adds a delay to how often you can click the mouse and trigger the animation
        if (Input.GetMouseButtonDown(0) && Time.time >= nextAllowedClickTime)
        {
            anim.Play("Swing", 0, 0f);
            nextAllowedClickTime = Time.time + clickCooldown;
        }
    }


}
