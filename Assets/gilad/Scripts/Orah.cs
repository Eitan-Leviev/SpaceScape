using System;
using UnityEngine;

namespace gilad.Scripts
{
    public class Orah : MonoBehaviour
    {
        // [SerializeField] private GameObject orah;

        [SerializeField] private bool switchMode = true;
        
        [SerializeField] private Sprite orah;

        [SerializeField] private SpriteRenderer renderer;

        [SerializeField] private Sprite original;

        [SerializeField] private GameObject back;

        


        public void TurnOn()
        {
            if(switchMode)
            {
                renderer.sprite = orah;
            }
            else
            {
                back.SetActive(true);
            }
        }

        public void TurnOf()
        {
            if(switchMode)
            {
                renderer.sprite = original;
            }
            else
            {
                back.SetActive(false);
            }
        }
    }
}
