using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody playerRigidbody;
    Animator animator;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        //playerRigidbody.AddForce(inputX * speed, 0, inputZ * speed);

        float fallSpeed = playerRigidbody.velocity.y;

        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        velocity *= speed;
        velocity.y = fallSpeed;
        //if (velocity != Vector3.zero)
        //{
        //    animator.SetBool("Run", true);
        //}
        //else
        //{
        //    animator.SetBool("Run", false);
        //}

        playerRigidbody.velocity = velocity;

    }
}
