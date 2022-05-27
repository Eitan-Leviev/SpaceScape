using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "ball")
        {
            GameObject.Find("ball").GetComponent<BallEitan>().ResetPlayer();
            // print("CCC");
        }
    }
}
