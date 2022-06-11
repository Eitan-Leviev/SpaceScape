using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Open : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject keysCheatTxt;
    [SerializeField] private GameObject canvas;
    


    public void ActivateStartButton()
    {
        button.SetActive(true);
        keysCheatTxt.SetActive(true);
        canvas.SetActive(true);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("level 1");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
