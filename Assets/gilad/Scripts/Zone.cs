using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    private static List<GameObject> allZones = new List<GameObject>();
    [SerializeField] private float speed = 1f;
    // Start is called before the first frame update

    private Transform _ball = null;
    void Start()
    {
        
    }

    private void Awake()
    {
        allZones.Add(gameObject);
        gameObject.SetActive(false);
        print(allZones.Count);
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
            print(i++);
            zone.SetActive(true);
        }
    }

    public static void Deactivate()
    {
        foreach (var zone in allZones)
        {
            zone.SetActive(false);
        }
    }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     print("trigger enter");
    //     _ball = other.gameObject.transform;
    // }
    //
    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     print("trigger exit");
    //     _ball = null;
    // }
    //
    // private void FixedUpdate()
    // {
    //     if (_ball != null)
    //     {
    //         var normal = (_ball.position - transform.position).normalized * speed;
    //         _ball.gameObject.GetComponent<Rigidbody2D>().AddForce(normal);
    //     }
    // }

    private void OnDestroy()
    {
        allZones.Remove(gameObject);
    }
}