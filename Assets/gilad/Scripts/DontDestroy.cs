using UnityEngine;

namespace gilad.Scripts
{
    public class DontDestroy : MonoBehaviour
    {
        private void Awake()
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag(gameObject.tag);
            print(gameObject.tag);
            print(obj);
            print(obj.Length);
            if (obj.Length > 1)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

    }
}
