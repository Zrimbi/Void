using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllAnimationPlayer : MonoBehaviour
{
    public Animator animator;
    private int timer = 0;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer += 1;
        if (PlayerController.walk == 'W')
        {
            animator.Play("Walk");
            timer = 0;
        }
        else if(PlayerController.walk == 'R')
        {
            animator.Play("Run");
            timer = 0;
        }
        else if (PlayerController.walk == 'I' && timer > 3720)
        {
            animator.Play("Idle");
        }
        else
        {
            animator.Play("Be");
        }
    }
}
