using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
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
            var normal = (_ball.position - transform.position).normalized * speed;
            _ball.gameObject.GetComponent<Rigidbody2D>().AddForce(normal);

        }
    }
}
