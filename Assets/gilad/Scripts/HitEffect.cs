using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{

    public static LinkedList<GameObject> Hits { get; set; }

    [SerializeField] private GameObject effect;

    private static GameObject Inst { get; set; }
    // Start is called before the first frame update
    
    public static void PlaceHit(Vector3 pos)
    {
        GameObject nextHit = null;
        if (Hits.Count == 0)
        {
            nextHit = Instantiate(Inst);
        }
        else
        {
            nextHit = Hits.First.Value;
            Hits.RemoveLast();
        }
        nextHit.SetActive(true);
    }

    void Deactivate()
    {
        Hits.AddFirst(gameObject);
        gameObject.SetActive(false);
    }
}
