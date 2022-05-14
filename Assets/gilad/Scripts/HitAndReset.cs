using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAndReset : MonoBehaviour
{
    public static void OnHit()
    {
        // print("On Hit");
        DragAndDrop.isActive = false;
        Zone.Activate();
        AddingItems.IsActive = false;
    }

    public static void OnReset()
    {
        DragAndDrop.isActive = true;
        Zone.Deactivate();
        AddingItems.IsActive = true;
    }
}
