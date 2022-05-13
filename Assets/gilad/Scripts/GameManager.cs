using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{

    private static GameManager shared;

    private LinkedList<GameObject> Hits = new LinkedList<GameObject>();

    [SerializeField] private GameObject hittEffectInst;
    
    [SerializeField] private int numWalls = 3;
    
    [SerializeField] private int numMagnets = 3;
    
    [SerializeField] private int numVents = 3;
    
    
    public int NumWalls
    {
        get => numWalls;
        set => numWalls = value;
    }

    public int NumMagnets
    {
        get => numMagnets;
        set => numMagnets = value;
    }

    public int NumVents
    {
        get => numVents;
        set => numVents = value;
    }
    // Start is called before the first frame update
    
    void Start()
    {
        shared = this;

        HitEffect.Hits = Hits;
    }
    
    public static void PlaceHit(Vector3 pos)
    {
        if (shared.Hits.Count == 0)
        {
            Instantiate(shared.hittEffectInst, pos, Quaternion.identity);
        }
        else
        {
            var nextHit = shared.Hits.Last.Value;
            nextHit.transform.position = pos;
            shared.Hits.RemoveLast();
            nextHit.SetActive(true);
        }
    }
}
