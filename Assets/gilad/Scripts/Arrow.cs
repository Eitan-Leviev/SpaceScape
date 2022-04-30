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
    
    private void Awake()
    {
        _instance = this;
    }

    public static Vector3 GetDirection()
    {
        _instance.gameObject.SetActive(false);
        return _instance.forward.position - _instance.backward.position;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _dir = _turnSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _dir = -_turnSpeed;
        }
        else
        {
            _dir = 0f;
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0,0,_dir * Time.fixedDeltaTime);
    }

    public static void Activate()
    {
        _instance.gameObject.SetActive(true);
    }

    private static void Deactivate()
    {
        _instance.gameObject.SetActive(false);
    }
}
