using UnityEngine;

namespace gilad.Scripts
{
    public class DontDestroy : MonoBehaviour
    {
        private void Awake()
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag(gameObject.tag);
            if (obj.Length > 1)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

    }
}
