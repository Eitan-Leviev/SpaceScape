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

    [SerializeField] private GameObject pointer;
    
    private float _dir = 0f;
    
    [SerializeField] private float _turnSpeed = 50f;

    [SerializeField] private BallEitan ball;
    
    private void Awake()
    {
        
        
        RotateItems.cur = transform;
        
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // gameObject.GetComponent<Animator>().SetTrigger("Shoot");
            Hit();
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
    
    void Hit()
    {
        transform.Find("LAZER").gameObject.SetActive(false);
        transform.Find("cannon").gameObject.SetActive(false);
        ball.Hit();
    }
}
