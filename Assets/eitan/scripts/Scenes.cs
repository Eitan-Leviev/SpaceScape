using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void ReloadScene()
    {
        HitAndReset.OnReset();
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        // SceneManager.LoadScene($"level {GameManager.Level}");
    }

    public void LodeNewScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
