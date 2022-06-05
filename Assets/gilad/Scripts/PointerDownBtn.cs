using UnityEngine;
using UnityEngine.EventSystems;

namespace gilad.Scripts
{
    public class PointerDownBtn : MonoBehaviour, IPointerDownHandler
    {

        [SerializeField] private int code;

        public void OnPointerDown(PointerEventData eventData)
        {
            AddingItems.Create(code);
        }
    }
}
