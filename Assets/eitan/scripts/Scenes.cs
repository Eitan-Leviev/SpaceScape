using System.Collections;
using System.Collections.Generic;
using gilad.Scripts;
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

    public static void LoadCurrLevel()
    {
        HitAndReset.OnReset();
        var newName = $"level {GameManager.Level}";
        if (SceneUtility.GetBuildIndexByScenePath(newName) < 0)
        {
            newName = "Ending";
        }
        SceneManager.LoadScene(newName);
    }
}
