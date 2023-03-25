using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAnimationScript : MonoBehaviour
{
    private Animator animator;
    private Animation animatorAnimation;

    void Start()
    {
        animator = GetComponent<Animator>();
        animatorAnimation = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("PlayAnimation");
        }
    }
}
