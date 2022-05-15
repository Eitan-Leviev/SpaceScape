using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{

    [SerializeField] private float turnSpeed = 0.01f;
    [SerializeField] private float speed = 1f;

    private float _moveSpeed = 1f;
    // Start is called before the first frame update

    private Transform _ball = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("trigger enter");
        _ball = other.gameObject.transform;
        _moveSpeed = _ball.GetComponent<BallEitan>().initSpeed * speed;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        print("trigger exit");
        _ball = null;
    }

    private void FixedUpdate()
    {
        if (_ball != null)
        {
            var ballRB = _ball.gameObject.GetComponent<Rigidbody2D>();
            
            var normal = (_ball.position - transform.position);
            if (normal.magnitude > Math.Abs(_moveSpeed))
            {
                normal = normal.normalized;
            }
            normal *= _moveSpeed;
            var curVelocity = ballRB.velocity;
            ballRB.velocity = Vector2.MoveTowards(curVelocity, normal, turnSpeed);

        }
        
    }
}
