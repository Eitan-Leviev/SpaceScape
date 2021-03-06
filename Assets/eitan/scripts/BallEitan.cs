using System;
using System.Collections;
using System.Collections.Generic;
using gilad.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

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
    public  bool moving = false;
    private Vector2 previousVelocity;

    private static BallEitan shared;

    private TrailRenderer _trail;

    [SerializeField] private AudioClip[] meows;

    [SerializeField] private AudioSource meow;
    [SerializeField] private AudioSource bomb;
    [SerializeField] private AudioSource moan;
    
    [SerializeField] private AudioSource winningPortal;

    [SerializeField] private int meowDoration = 3;

    private GameObject editModeObj;
    


    private void Awake()
    {
        Time.timeScale = 1;
        shared = this;
        editModeObj = GameObject.Find("grid");
        dir = transform.parent.gameObject;
        rb = GetComponent<Rigidbody2D>();
        previousVelocity = rb.velocity;

        initPos = transform.localPosition;
        initRotation = transform.localRotation;
        _trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        previousVelocity = rb.velocity;
        
    }

    public void Hit()
    {
        moan.Play();
        bomb.Play();
        if(Random.Range(0, meowDoration) == 0)
        {
            meow.clip = meows[Random.Range(0, meows.Length)];
            meow.Play();
        }
        
        if (editModeObj)
        {
            editModeObj.GetComponent<Animator>().SetTrigger("fade");
        }
        // get direction
        Vector3 velocity = Arrow.GetDirection();
        // give initial velocity
        rb.velocity = velocity * initSpeed;
        moving = true;
        _trail.enabled  = true;
        _trail.emitting = true;
        HitAndReset.OnHit();
        
    }

    private double SlowDownFunc(float x)
    {
        return -0.01 * Math.Pow(x, 2) + initSpeed;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        var skweez = other.gameObject.GetComponent<Skweez>();
        if (skweez != null)
        {
            skweez.DoSkweez();
        }
        ContactPoint2D contact = other.contacts[0];

        Vector2 contactNormal = contact.normal;

        Vector2 newVelocity = Vector2.Reflect(previousVelocity, contactNormal);

        rb.velocity = newVelocity;
        
        previousVelocity = newVelocity;
        
        GameManager.PlaceHit(transform.position);
        
        print("yo");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "target")
        {
            // portal anim
            other.gameObject.GetComponent<Animator>().SetTrigger("portal winning");
            // win sound
            winningPortal.Play();
            GameObject.Find("BG").GetComponent<AudioSource>().Play();
            // moan.Play();
            // transform.parent.gameObject.GetComponent<AudioSource>().Play();
            // transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();

            var canvas = GameObject.Find("Canvas");
            canvas.SetActive(false);
            Time.timeScale = 1;
            GameManager.Level++;
            Invoke("Sus", 1f);
            Invoke("SetActiveFalse", 0.07f);
        }
    }

    public void Sus()
    {
        GameManager.WinLevel();
    }

    private void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
    
    private void OnMouseDown()
    {
        RotateItems.Cur = dir.transform;
    }

    public void ResetPlayer()
    {
        var t = transform;
        transform.parent = dir.transform;
        _trail.emitting = false;
        dir.transform.Find("Lazer").gameObject.SetActive(true);
        gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
        t.localPosition = initPos;
        t.localRotation = initRotation;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        if (editModeObj)
        {
            editModeObj.GetComponent<Animator>().SetTrigger("back");
        }
        RotateItems.Cur = transform.parent;
        moving = false;
        Time.timeScale = 1;
        HitAndReset.OnReset();
        _trail.Clear();
    }

    public static void BallReset()
    {
        shared.ResetPlayer();
    }
}
