using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using gilad.Scripts;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private bool isDefault = false;
    public static bool isActive = true;
    private GameObject obj;
    private bool isDragging = true;

    private Vector2 _offset = Vector2.zero;

    private Vector3 originalScale;

    private float _curScale = 1f;

    public static float _scaleDecrease = 0.6f;
    
    public float speed = 2; // Units per second
    private int flipper = 0; // 1 to grow, 2 to shrink, 0 do nothing
    
    public static Transform Trash { get; set; }

    private Collider2D[] _allCollisions;

    public bool isTrash = false;

    public bool IsTrash
    {
        get => isTrash;
        set
        {
            flipper = value ? 1 : 2;
            isTrash = value;
        }
    }

    private void Start()
    {
        var transform1 = transform;
        if (!isDefault) RotateItems.Cur = transform1;
        originalScale = transform1.localScale;
        isTrash = false;
    }

// Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            var touch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // print(touch);
            if (!Input.GetMouseButton(0) && isDragging)
            {
                StopDrag();
            }

            if (isDragging)
            {
                var t = transform;
                t.position = new Vector3(touch.x - _offset.x, touch.y - _offset.y, t.position.z);
                // ReSharper disable once Unity.PreferNonAllocApi
                _allCollisions = Physics2D.OverlapCircleAll(touch, 0.0f);
                foreach (var collider1 in _allCollisions)
                {
                    if (collider1.CompareTag("Trash"))
                    {
                        IsTrash = true;
                        ButtonHovering.Active = false;
                        break;
                    }
                    IsTrash = false;
                    ButtonHovering.Active = true;
                }
            }
        }
        Resize();
    }
    
    private void Resize()
    {
        float movement = speed * Time.deltaTime;

        if (flipper == 1) // shrink
        {
            if (_curScale >  _scaleDecrease)
            {
                _curScale -= movement;
            }
            else
            {
                flipper = 0;
                _curScale = _scaleDecrease;
            }
        }
        if (flipper == 2) // grow
        {
            if (_curScale < 1)
            {
                _curScale += movement;
            }
            else
            {
                flipper = 0;
                _curScale = 1;
            }
        }
        transform.localScale = originalScale * _curScale;
    }
    
    private void OnMouseDown()
    {
        _offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        isDragging = true;
        RotateItems.Cur = transform;
        if (!isActive)
        {
            BallEitan.BallReset();
        }
    }

    private void OnMouseUp()
    {
        if (isActive)
        {
            // print(2);
            StopDrag();
        }
    }

    private void StopDrag()
    {
        isDragging = false;
        RotateItems.Cur = RotateItems.Default;
        if (isTrash)
        {
            switch (gameObject.tag)
            {
                case "Wall":
                    GameManager.NumWalls++;
                    break;
                case "Magnet":
                    GameManager.NumMagnets++;
                    break;
                case "Vent":
                    GameManager.NumVents++;
                    break;
            }

            ButtonHovering.Active = true;
            RotateItems.Cur = null;
            ValuesManager.UpdateQuants();
            Destroy(gameObject);
        }
    }
}