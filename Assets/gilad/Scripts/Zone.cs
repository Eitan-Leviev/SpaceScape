using System.Collections.Generic;
using UnityEngine;

namespace gilad.Scripts
{
    public class Zone : MonoBehaviour
    {
        private static List<GameObject> allZones = new List<GameObject>();

        // Start is called before the first frame update

        private Transform _ball = null;
        void Start()
        {
        
        }

        private void Awake()
        {
            allZones.Add(gameObject);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            // print(allZones.Count);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public static void Activate()
        {
            int i = 0;
            foreach (var zone in allZones)
            {
                zone.GetComponent<CircleCollider2D>().enabled = true;
            }
        }

        public static void Deactivate()
        {
            foreach (var zone in allZones)
            {
                zone.GetComponent<CircleCollider2D>().enabled = false;
            }
        }

        private void OnDestroy()
        {
            allZones.Remove(gameObject);
        }
    }
}