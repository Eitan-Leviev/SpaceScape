using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AddingItems : MonoBehaviour
{
    [SerializeField] private Vector2 itemsInitPos; 
    
    [SerializeField] private GameObject wall; // item code = 1 
    [SerializeField] private GameObject ventilator; // item code = 3
    [SerializeField] private GameObject magnet; // item code = 2

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateItem(int itemCode)
    {
        print("k");
        
        GameObject item = null;
        switch (itemCode)
        {
            case 1:
                item = wall;
                break;
            case 2:
                item = magnet;
                break;
            case 3:
                item = ventilator;
                break;
        }
        Instantiate(item, itemsInitPos, quaternion.identity);
    }
}
