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
    public float initSpeed = 20;
    // public float speed = 1;
    private float x = 0;
    public static bool moving = false;
    private Vector2 previousVelocity;

    [SerializeField] private AudioSource bomb;
    [SerializeField] private AudioSource moan;

    private GameObject editModeObj;
    


    private void Awake()
    {
        // Time.timeScale = 2;
        Time.timeScale = 1;

        editModeObj = GameObject.Find("grid");
        dir = transform.parent.gameObject;
        rb = GetComponent<Rigidbody2D>();
        previousVelocity = rb.velocity;

        initPos = transform.localPosition;
        initRotation = transform.localRotation;
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
        moan.Play();
        bomb.Play();
        editModeObj.GetComponent<Animator>().SetTrigger("fade");
        // GetComponent<AudioSource>().Play();
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
            var canvas = GameObject.Find("Canvas");
            canvas.SetActive(false);
            Time.timeScale = 1;
            GameManager.Level++;
            GameManager.WinLevel();
            gameObject.SetActive(false);
        }
    }
    
    private void OnMouseDown()
    {
        // print("j");
        RotateItems.Cur = dir.transform;
    }

    public void ResetPlayer()
    {
        var t = transform;
        transform.parent = dir.transform;
        dir.transform.Find("Lazer").gameObject.SetActive(true);
        gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
        t.localPosition = initPos;
        t.localRotation = initRotation;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        editModeObj.GetComponent<Animator>().SetTrigger("back");
        RotateItems.Cur = transform.parent;

        moving = false;
        Time.timeScale = 1;
        
        HitAndReset.OnReset();
    }
}
