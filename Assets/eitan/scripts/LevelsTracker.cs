using System;
using System.Collections;
using System.Collections.Generic;
using gilad.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class LevelsTracker : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Text>().text = $"Level {GameManager.Level} | 17";
    }
}
