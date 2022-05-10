using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAndReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void OnHit()
    {
        print("On Hit");
        DragAndDrop.isActive = false;
        Zone.Activate();
    }

    public static void OnReset()
    {
        DragAndDrop.isActive = true;
        Zone.Deactivate();
    }
}
