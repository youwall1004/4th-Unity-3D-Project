using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimator : MonoBehaviour
{
    Animator animator;
    Rigidbody body;
    float moveSpeed = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(animator.GetFloat("Forward") >= 0.9f)
        {
            Debug.Log("TEst");
            body.velocity = new Vector3(body.velocity.x,
                                       body.velocity.y,
                                       animator.GetFloat("Forward"));
        }
    }
}
