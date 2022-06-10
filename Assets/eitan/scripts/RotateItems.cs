using System;
using System.Collections;
using System.Collections.Generic;
using gilad.Scripts;
using UnityEngine;

public class RotateItems : MonoBehaviour
{
    private bool stillCurr = false;
    
    public static bool NeedToCur { get; set; }
    [SerializeField] private float removeIn = 0.5f;

    private float counterToRemove = 0;

    private static Transform cur;

    private float _dir = 0f;
    [SerializeField] private float _turnSpeed = 500f;

    private static RotateItems shared;


    public static Transform Default { get; set; }

    public static Transform Cur
    {
        get => cur;
        set
        {
            if (shared.stillCurr) return;
            if (value == null || value.CompareTag("Magnet") || value.CompareTag("Vent"))
            {
                value = Default;
            }

            Orah orah = null;
            if(cur != null) orah = cur.GetComponent<Orah>();
            if(orah != null) orah.TurnOf();
            // if (cur != null) cur.GetComponent<SpriteRenderer>().color = Color.white;
            cur = value;
            orah = cur.GetComponent<Orah>();
            if(orah != null) orah.TurnOn();
            // value.GetComponent<SpriteRenderer>().color = shared.editColor;
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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform == null)
            {
                Cur = Default;
            }
        }
        // print(cur.parent.name);

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            stillCurr = true;
            counterToRemove = 0f;
            // print("R");
            if (GameManager.Level == 2)
            {
                GameObject.Find("Canvas").GetComponent<TutorialManager>().rotateCannonTutorialEnding();
            }
            _dir = -_turnSpeed;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            counterToRemove = 0f;
            stillCurr = true;
            // print("L");
            _dir = _turnSpeed;
        }
        else
        {
            stillCurr = false;
            counterToRemove += Time.deltaTime;
            if (NeedToCur && counterToRemove > removeIn)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.transform == null)
                {
                    Cur = Default;
                }
            }
            _dir = 0f;
        }

        if (Cur != null)
        {
            Cur.Rotate(0, 0, _dir * Time.fixedDeltaTime);
        }
    }
}