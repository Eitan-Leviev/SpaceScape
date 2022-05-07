using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveCopy : MonoBehaviour
{
    private GameObject dir;
    private Rigidbody2D rb;
    public float initSpeed = 10;
    public float speed = 1;
    private float x = 0;
    private bool moving = false;
    private Vector2 previousVelocity;

    private void Awake()
    {
        dir = gameObject;
        rb = GetComponent<Rigidbody2D>();
        previousVelocity = rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        previousVelocity = rb.velocity;

        // hit
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Shoot");
        }

        if (moving)
        {
            // add to x
            x += Time.deltaTime * speed;
            var y = SlowDownFunc(x);
            // slow down ball
            if (y <= 0)
            {
                print("stop moving");
                rb.velocity = Vector2.zero;
                moving = false;
                x = 0;
                Arrow.Activate();
            }
            else
            {
                rb.velocity = rb.velocity.normalized * (float) y;
            }
        }
    }

    public void Hit()
    {
        // get direction
        // var velocity = Vector2.left;
        Vector3 velocity = Arrow.GetDirection();
        // give initial velocity
        rb.velocity = velocity * initSpeed;
        moving = true;
    }

    private double SlowDownFunc(float x)
    {
        return -0.01 * Math.Pow(x, 2) + initSpeed;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        ContactPoint2D contact = other.contacts[0];

        Vector2 contactNormal = contact.normal;

        Vector2 newVelocity = Vector2.Reflect(previousVelocity, contactNormal);
        print(previousVelocity);
        print(newVelocity);

        rb.velocity = newVelocity;
        
        previousVelocity = newVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "target")
        {
            print("win");
            gameObject.SetActive(false);
        }
    }

    
}
