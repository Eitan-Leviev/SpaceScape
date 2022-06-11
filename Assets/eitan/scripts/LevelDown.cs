using System.Collections;
using System.Collections.Generic;
using gilad.Scripts;
using UnityEngine;

public class LevelDown : MonoBehaviour
{
    public void LevelDownFunc()
    {
        GameObject.Find("script objects").transform.Find("gameManager").gameObject.GetComponent<GameManager>().LevelDown();
    }
}

