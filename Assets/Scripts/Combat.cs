using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private Animator anim;
    public float comboResetTime = 1.0f; // Time before the combo resets
    private float lastAttackTime;
    private int noOfClicks = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Reset combo if too much time has passed
        if (Time.time - lastAttackTime > comboResetTime)
        {
            noOfClicks = 0;
            ResetCombo();
        }

        // Check if we can continue the combo (animation must have played at least 70%)
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        
        if (stateInfo.normalizedTime > 0.7f && stateInfo.IsName("hit1") && noOfClicks >= 2)
        {
            anim.SetBool("hit1", false);
            anim.SetBool("hit2", true);
        }
        if (stateInfo.normalizedTime > 0.7f && stateInfo.IsName("hit2") && noOfClicks >= 3)
        {
            anim.SetBool("hit2", false);
            anim.SetBool("hit3", true);
        }
        if (stateInfo.normalizedTime > 0.7f && stateInfo.IsName("hit3"))
        {
            anim.SetBool("hit3", false);
            noOfClicks = 0; // Reset after last attack
        }

        // Detect input
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        lastAttackTime = Time.time; // Update attack time
        noOfClicks++;

        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3); // Ensure the counter stays within bounds

        if (noOfClicks == 1)
        {
            anim.SetBool("hit1", true);
        }
    }

    void ResetCombo()
    {
        anim.SetBool("hit1", false);
        anim.SetBool("hit2", false);
        anim.SetBool("hit3", false);
    }
}
