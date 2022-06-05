using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private GameObject canvas;
    
    public static bool LeftClickTutorialDoneFlag = false;
    
    public static bool rotateCannonTutorialDoneFlag = false;

    [SerializeField] private GameObject scroller;
    

    private void Awake()
    {
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ScrollOn();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ScrollOff();
        }
    }

    public void LeftClickTutorialEnding()
    {
        GetComponent<Animator>().SetBool("done", false);
    }
    
    public void rotateCannonTutorialEnding()
    {
        // scroll disappear 
        GameObject.Find("tutor scroll canon").GetComponent<Animator>().SetTrigger("fade out");
        // R click appear 
        GameObject.Find("tutor R click").GetComponent<Animator>().SetTrigger("fade in");
    }

    public void ScrollOn()
    {
        scroller.SetActive(true);
    }
    
    public void ScrollOff()
    {
        scroller.SetActive(false);
    }
}
