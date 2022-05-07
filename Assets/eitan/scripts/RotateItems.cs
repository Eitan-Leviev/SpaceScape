using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItems : MonoBehaviour
{
    public static Transform cur;
    
    private float _dir = 0f;
    [SerializeField] private float _turnSpeed = 50f;

    private void Awake()
    {
        // cur = transform;
    }

    // Update is called once per frame
    void Update()
    {
        // print(cur.parent.name);
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _dir = -_turnSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _dir = _turnSpeed;
        }
        else
        {
            _dir = 0f;
        }
        
        cur.Rotate(0,0,_dir * Time.fixedDeltaTime);
    }
}
