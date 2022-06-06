using System;
using System.Collections;
using System.Collections.Generic;
using gilad.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackHoleTutor : MonoBehaviour
{
    [SerializeField] private int timeOfDemo = 7;
    
    
    private void Awake()
    {
        Invoke("LoadNewScene", timeOfDemo);
    }

    private void LoadNewScene()
    {
        var canvas = GameObject.Find("Canvas");
        canvas.SetActive(false);
        Time.timeScale = 1;
        GameManager.Level++;
        
        // reload scene 
        HitAndReset.OnReset();
        var newName = $"level {GameManager.Level}";
        if (SceneUtility.GetBuildIndexByScenePath(newName) < 0)
        {
            newName = "Ending";
        }
        SceneManager.LoadScene(newName);
        // GameManager.WinLevel();
    }
}
