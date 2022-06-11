using System.Collections;
using System.Collections.Generic;
using gilad.Scripts;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public void LevelUpFunc()
    {
        GameObject.Find("script objects").transform.Find("gameManager").gameObject.GetComponent<GameManager>().LevelUp();
    }
}
