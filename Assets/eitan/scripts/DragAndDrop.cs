using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private GameObject obj;
    
    private bool moveAllowed;
    private Collider2D col;

    private Vector2 touchBegin;
    private Vector2 touchEnd;
    
    private void Awake()
    {
        print("awake");
        col = GetComponent<Collider2D>();
        // editPopUp = GameObject.Find("Canvas").transform.Find("ohadPopUp").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        print(Input.touchCount);
        if (Input.touchCount == 1)
        {
            print("k");
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            
            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchColl = Physics2D.OverlapPoint(touchPosition);
                if (col == touchColl)
                {
                    moveAllowed = true;
                    touchBegin = touchPosition;
                }
            }
            
            if (touch.phase == TouchPhase.Moved)
            {
                if (moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }
            
            if (touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
                touchEnd = touchPosition;

                // detect click
                // if (touchBegin == touchEnd)
                // {
                //     print();
                // }
            }
        }
    }

    public void OnClick()
    {
        print("click");
    }
}
