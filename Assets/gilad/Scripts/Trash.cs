using UnityEngine;

namespace gilad.Scripts
{
    public class Trash : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            DragAndDrop.Trash = transform;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

    
    }
}
