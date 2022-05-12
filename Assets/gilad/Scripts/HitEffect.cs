using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{

    private static LinkedList<GameObject> hits;

    [SerializeField] private GameObject effect;

    private static GameObject Inst { get; set; }
    // Start is called before the first frame update
    
    public static void PlaceHit(Vector3 pos)
    {
        GameObject nextHit = null;
        if (hits.Count == 0)
        {
            nextHit = Instantiate(Inst);
        }
        else
        {
            nextHit = hits.First.Value;
            hits.RemoveLast();
        }
        nextHit.SetActive(true);
    }

    void Deactivate()
    {
        hits.AddFirst(gameObject);
        gameObject.SetActive(false);
    }
}
