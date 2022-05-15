using System;
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
    
    
    public static int NumWalls
    {
        get => shared.numWalls;
        set => shared.numWalls = Math.Max(value, 0);
    }

    public static int NumMagnets
    {
        get => shared.numMagnets;
        set => shared.numMagnets = Math.Max(value, 0);
    }

    public static int NumVents
    {
        get => shared.numVents;
        set => shared.numVents = Math.Max(value, 0);
    }
    // Start is called before the first frame update
    
    void Start()
    {
        shared = this;
        ValuesManager.UpdateQuants();
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
