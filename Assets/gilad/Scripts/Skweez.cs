using UnityEngine;

namespace gilad.Scripts
{
    public class Skweez : MonoBehaviour
    {
        [SerializeField] private Animator skweez;


        public void DoSkweez()
        {
            skweez.SetTrigger("Skweez");
        }
    }
}
