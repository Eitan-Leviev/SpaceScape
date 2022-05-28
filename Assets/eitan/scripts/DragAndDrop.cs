using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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

    public static float _scaleDecrease = 0.6f;

    public static Transform Trash { get; set; }

    private Collider2D[] _allCollitions;

    public bool isTrash = false;

    public bool IsTrash
    {
        get => isTrash;
        set 
        {
            if (value)
            {
                transform.localScale *= _scaleDecrease;
            }
            else
            {
                transform.localScale = originalScale;
            }
            isTrash = value;
        }
}

private void Start()
{
    var transform1 = transform;
    if(!isDefault)RotateItems.Cur = transform1;
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
            _allCollitions = Physics2D.OverlapCircleAll(touch, 0.0f);
            foreach (var collider in _allCollitions)
            {
                if (collider.CompareTag("Trash"))
                {
                    IsTrash = true;
                }
                else
                {
                    IsTrash = false;
                }
            }

        }
    }
}


private void OnMouseDown()
{
    if (isActive)
    {
        // print(1);
        _offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        isDragging = true;
        RotateItems.Cur = transform;
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

        RotateItems.Cur = null;
        ValuesManager.UpdateQuants();
        Destroy(gameObject);
    }
}
}