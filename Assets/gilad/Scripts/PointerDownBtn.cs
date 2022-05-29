using UnityEngine;
using UnityEngine.EventSystems;

namespace gilad.Scripts
{
    public class PointerDownBtn : MonoBehaviour, IPointerDownHandler
    {

        [SerializeField] private int code;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    

        public void OnPointerDown(PointerEventData eventData)
        {
            AddingItems.Create(code);
        }
    }
}
