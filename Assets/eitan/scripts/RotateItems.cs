using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItems : MonoBehaviour
{
    [SerializeField] private Color editColor;
    
    private static Transform cur;
    
    private float _dir = 0f;
    [SerializeField] private float _turnSpeed = 50f;

    private static RotateItems shared;

    
    public static Transform Cur
    {
        get => cur;
        set
        {
            if(value == null || (value.tag != "Magnet" && value.tag != "Vent"))
            {
                if (cur != null) cur.GetComponent<SpriteRenderer>().color = Color.white;
                cur = value;
                if (value != null) value.GetComponent<SpriteRenderer>().color = shared.editColor;
            }
        }
    }

    private void Start()
    {
        shared = this;
    }
    
    private void Awake()
    {
        shared = this;
    }

    // Update is called once per frame
    void Update()
    {
        // print(cur.parent.name);
        
        if (Input.GetAxis( "Mouse ScrollWheel" ) > 0)
        {
            // print("R");
            _dir = -_turnSpeed;
        }
        else if (Input.GetAxis( "Mouse ScrollWheel" ) < 0)
        {
            // print("L");
            _dir = _turnSpeed;
        }
        else
        {
            _dir = 0f;
        }
        
        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     print("R");
        //     _dir = -_turnSpeed;
        // }
        // else if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     print("L");
        //     _dir = _turnSpeed;
        // }
        // else
        // {
        //     _dir = 0f;
        // }

        if(Cur != null)
        {
            
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                if (Cur.CompareTag("Ball"))
                { // todo change to compere tag
                    return;
                }
                // print(cur.tag);
                switch (Cur.tag)
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
                Destroy(Cur.gameObject);
                Cur = null;
                ValuesManager.UpdateQuants();
                return;
            }
            Cur.Rotate(0, 0, _dir * Time.fixedDeltaTime);
        }
    }
}
