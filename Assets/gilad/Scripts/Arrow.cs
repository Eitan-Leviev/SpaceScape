using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Arrow : MonoBehaviour
{
    private static Arrow _instance;

    [SerializeField] private Transform forward;
    
    [SerializeField] private Transform backward;

    
    
    private float _dir = 0f;
    
    [SerializeField] private float _turnSpeed = 50f;

    [SerializeField] private BallEitan ball;

    private static bool isActive = true;

    public static bool IsActive
    {
        get => isActive;
        set => isActive = value;
    }

    private void Awake()
    {
        
        
        RotateItems.Cur = transform;
        
        _instance = this;
    }

    public static Vector3 GetDirection()
    {
        //Deactivate();
        return _instance.forward.position - _instance.backward.position;
    }

    private void Update()
    {
        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     _dir = -_turnSpeed;
        // }
        // else if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     _dir = _turnSpeed;
        // }
        // else
        // {
        //     _dir = 0f;
        // }

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     // gameObject.GetComponent<Animator>().SetTrigger("Shoot");
        //     Hit();
        // }

        if (Input.GetMouseButtonDown(1))
        {
            if (! BallEitan.moving)
            {
                Time.timeScale = 2;
                Hit();
            }
            else
            {
                var ballScript = GameObject.Find("ball").gameObject.GetComponent<BallEitan>();
                ballScript.ResetPlayer();
            }
        }
        
    }

    // private void FixedUpdate()
    // {
    //     CurrRotate.curr.Rotate(0,0,_dir * Time.fixedDeltaTime);
    // }

    public static void Activate()
    {
        _instance.gameObject.SetActive(true);
    }

    private static void Deactivate()
    {
        _instance._dir = 0f;
        _instance.gameObject.SetActive(false);
    }
    
    public void Hit()
    {
        if(isActive)
        {
            // transform.Find("LAZER").gameObject.SetActive(false);
            transform.Find("Lazer").gameObject.SetActive(false);
            ball.transform.SetParent(null);
            ball.GetComponent<CircleCollider2D>().isTrigger = false;
            ball.Hit();
        }
    }
}
