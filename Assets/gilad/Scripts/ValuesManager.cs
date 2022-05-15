using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValuesManager : MonoBehaviour
{
    private static ValuesManager shared;

    [SerializeField] private TextMeshProUGUI wallTxt;
    
    [SerializeField] private TextMeshProUGUI magnetTxt;
    
    [SerializeField] private TextMeshProUGUI ventsTxt;
    // Start is called before the first frame update
    void Start()
    {
        shared = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdateQuants()
    {
        if(shared.magnetTxt != null)shared.magnetTxt.text = GameManager.NumMagnets.ToString();
        if(shared.ventsTxt != null)shared.ventsTxt.text = GameManager.NumVents.ToString();
        if(shared.wallTxt != null)shared.wallTxt.text = GameManager.NumWalls.ToString();
    }
}
