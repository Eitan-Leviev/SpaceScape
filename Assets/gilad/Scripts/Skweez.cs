using System.Collections;
using UnityEngine;

namespace gilad.Scripts
{
    public class Skweez : MonoBehaviour
    {
        [SerializeField] private Animator skweez;


        [SerializeField] private float duration = 0.13f;

        [SerializeField] private float magnitude = 0.6f;

        [SerializeField] private Transform skweezer;
        
        public void DoSkweez()
        {
            skweez.SetTrigger("Skweez");
            StartCoroutine(Shake());
        }
        
        IEnumerator Shake()
        {
            var originalPosition = skweezer.localPosition;
            float elapsed = 0f;
            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;
                skweezer.localPosition = new Vector3(x, y, originalPosition.z);
                elapsed += Time.deltaTime;
                yield return null;
            }
            skweezer.localPosition = originalPosition;
        }
    }
}
