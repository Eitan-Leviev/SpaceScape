using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHovering : MonoBehaviour
{
    public float speed = 1; // Units per second
    private int flipper = 0; // 1 to shrink, 2 to grow, 0 do nothing
    [SerializeField] private float maxSize = 1.2f;
    

    // Update is called once per frame
    void Update()
    {
        print(flipper);
        
        float movement = speed * Time.deltaTime;

        if (flipper == 1) // shrink
        {
            if (transform.localScale.y > 1)
            {
                Vector3 scale = transform.localScale;
                scale.x -= movement;
                scale.y -= movement;
                scale.z -= movement;
                transform.localScale = scale;
            }
            else
            {
                flipper = 0;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        
        if (flipper == 2) // grow
        {
            if (transform.localScale.y < maxSize)
            {
                Vector3 scale = transform.localScale;
                scale.x += movement;
                scale.y += movement;
                scale.z += movement;
                transform.localScale = scale;
            }
            else
            {
                flipper = 0;
                transform.localScale = new Vector3(maxSize, maxSize, maxSize);
            }
        }
    }
    
    private void OnMouseEnter()
    {
        flipper = 2; // grow
    }

    private void OnMouseExit()
    {
        flipper = 1; // shrink
    }
}
