using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void ReloadScene()
    {
        HitAndReset.OnReset();
        SceneManager.LoadScene($"level {GameManager.Level}");
    }
}
