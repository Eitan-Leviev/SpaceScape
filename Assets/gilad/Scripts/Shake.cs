using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace gilad.Scripts
{
    public class Shake : MonoBehaviour
    {
        [SerializeField] private float duration = 0.6f;

        [SerializeField] private float magnitude = 0.6f;
        // Start is called before the first frame update

        private static Shake shared;

        private void Start()
        {
            shared = this;
        }

        public static void ShakeMe()
        {
            
            if (shared == null) return;
            shared.StartCoroutine(shared.CameraShake());
        }
        
        IEnumerator CameraShake()
        {
            var originalPosition = transform.position;
            float elapsed = 0f;
            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;
                transform.localPosition = new Vector3(x, y, originalPosition.z);
                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.position = originalPosition;
        }
   
    }
}
