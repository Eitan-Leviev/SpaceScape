using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHovering : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float speed = 2; // Units per second
    private int flipper = 0; // 1 to shrink, 2 to grow, 0 do nothing
    [SerializeField] private float maxSize = 1.4f;
    // private RectTransform _transform;

    private void Awake()
    {
        // GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        // print(1);
        flipper = 2; // grow
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        // print(2);
        flipper = 1; // shrink
    }
    
}
