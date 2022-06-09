using UnityEngine;

namespace gilad.Scripts
{
    public class Orah : MonoBehaviour
    {
        [SerializeField] private GameObject orah;


        public void TurnOn()
        {
            orah.SetActive(true);
        }

        public void TurnOf()
        {
            orah.SetActive(false);
        }
    }
}
