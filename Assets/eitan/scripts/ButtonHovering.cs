using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHovering : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool Active { set; get; }
    [SerializeField] private Image[] _images;

    private Color32 zeroColor;
    private Color32 myColor;
    public float speed = 2; // Units per second
    private int flipper = 0; // 1 to shrink, 2 to grow, 0 do nothing

    [SerializeField] private byte alpha = 75;
    
    private bool isZero = false;

    public bool IsZero
    {
        get => isZero;
        set
        {
            isZero = value;
            if (value)
            {
                foreach (var _image in _images)
                {
                    _image.color = zeroColor;
                }
            }
            else
            {
                foreach (var _image in _images)
                {
                    _image.color = myColor;
                }
            }
        }
    }

    [SerializeField] private float maxScale = 1.4f;

    private Vector3 initScale;
    // private RectTransform _transform;

    private void Awake()
    {
        Active = true;
        initScale = transform.localScale;
    }

    private void Start()
    {

        myColor = _images[0].color;
        zeroColor = myColor;
        zeroColor.a = alpha;
    }


    // Update is called once per frame
    void Update()
    {
        float movement = speed * Time.deltaTime;

        if (flipper == 1) // shrink
        {
            if (transform.localScale.y > initScale.y)
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
                transform.localScale = initScale;
            }
        }
        if (!Active || IsZero) return;
        if (flipper == 2) // grow
        {
            if (transform.localScale.y < initScale.y * maxScale)
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
                transform.localScale = initScale * maxScale;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
 
        flipper = 2; // grow
    }

    public void OnPointerExit(PointerEventData eventData)
    {
 
        flipper = 1; // shrink
    }
}