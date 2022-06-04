using UnityEngine;
using UnityEngine.SceneManagement;

namespace gilad.Scripts
{
    public class TransitionMnager : MonoBehaviour
    {
        // Start is called before the first frame update

    
        public void ReloadScene()
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
}
