using System;
using System.Collections;
using System.Collections.Generic;
using gilad.Scripts;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.parent.gameObject.GetComponent<Arrow>().Hit();
    }
}
