using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEitan : MonoBehaviour
{
    public static bool IsEditingBall = true;

    private Vector3 initPos;
    private Quaternion initRotation;

    private GameObject dir;
    private Rigidbody2D rb;
    public float initSpeed = 10;
    // public float speed = 1;
    private float x = 0;
    private bool moving = false;
    private Vector2 previousVelocity;

    private void Awake()
    {
        dir = transform.Find("Arrow").gameObject;
        rb = GetComponent<Rigidbody2D>();
        previousVelocity = rb.velocity;

        initPos = transform.position;
        initRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        previousVelocity = rb.velocity;

        // // hit
        // if (!moving && Input.GetKeyDown(KeyCode.Space))
        // {
        //     Hit();
        // }

        if (moving)
        {
            // slow down ball
            
            // // add to x
            // x += Time.deltaTime * speed;
            // var y = SlowDownFunc(x);
            
            // if (y <= 0)
            // {
            //     print("stop moving");
            //     rb.velocity = Vector2.zero;
            //     moving = false;
            //     x = 0;
            //     Arrow.Activate();
            // }
            // else
            // {
            //     rb.velocity = rb.velocity.normalized * (float) y;
            // }
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
        HitAndReset.OnHit();
        
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
        // print(previousVelocity);
        // print(newVelocity);

        rb.velocity = newVelocity;
        
        previousVelocity = newVelocity;
        
        GameManager.PlaceHit(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "target")
        {
            // print("win");
            gameObject.SetActive(false);
        }
    }
    
    private void OnMouseDown()
    {
        // print("j");
        RotateItems.cur = dir.transform;
    }

    public void ResetPlayer()
    {
        var t = transform;
        t.position = initPos;
        t.rotation = initRotation;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        HitAndReset.OnReset();
    }
}
