using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItems : MonoBehaviour
{
    public static Transform cur;
    
    private float _dir = 0f;
    [SerializeField] private float _turnSpeed = 50f;


    
    

    private void Awake()
    {
        // cur = transform;
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

        if(cur != null)
        {
            
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                if (cur.CompareTag("Ball"))
                { // todo change to compere tag
                    return;
                }
                print(cur.tag);
                switch (cur.tag)
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
                Destroy(cur.gameObject);
                cur = null;
                ValuesManager.UpdateQuants();
                return;
            }
            cur.Rotate(0, 0, _dir * Time.fixedDeltaTime);
        }
    }
}
