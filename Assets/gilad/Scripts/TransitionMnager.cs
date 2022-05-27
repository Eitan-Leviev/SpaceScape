using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionMnager : MonoBehaviour
{
    // Start is called before the first frame update

    
    public void ReloadScene()
    {
        HitAndReset.OnReset();
        SceneManager.LoadScene($"level {GameManager.Level}");
        // SceneManager.LoadScene("game");
    }
}
