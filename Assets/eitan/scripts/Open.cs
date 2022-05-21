using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Open : MonoBehaviour
{
    [SerializeField] private GameObject button;
    

    public void ActivateStartButton()
    {
        button.SetActive(true);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("level 1");
    }
}
