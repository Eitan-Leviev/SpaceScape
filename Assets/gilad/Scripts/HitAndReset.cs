using System.Collections;
using System.Collections.Generic;
using gilad.Scripts;
using UnityEngine;

public class HitAndReset : MonoBehaviour
{
    public static void OnHit()
    {
        DragAndDrop.isActive = false;
        Zone.Activate();
        AddingItems.IsActive = false;
        Arrow.IsActive = false;
        RotateItems.Cur = null;
    }

    public static void OnReset()
    {
        DragAndDrop.isActive = true;
        Zone.Deactivate();
        AddingItems.IsActive = true;
        Arrow.IsActive = true;
        GameManager.NumTries++;
    }
}
