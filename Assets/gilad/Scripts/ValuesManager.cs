using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValuesManager : MonoBehaviour
{
    private static ValuesManager shared;

    private Color32 zeroColor;

    private Color32 originaleColor;

    [SerializeField] private byte alpha = 75;

    [SerializeField] private TextMeshProUGUI wallTxt;
    
    [SerializeField] private TextMeshProUGUI magnetTxt;
    
    [SerializeField] private TextMeshProUGUI ventsTxt;
    // Start is called before the first frame update
    void Start()
    {
        zeroColor = wallTxt.faceColor;
        originaleColor = wallTxt.faceColor;
        shared = this;
        zeroColor.a = alpha;
        print(originaleColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void UpdateQuants()
    {
        // print(shared.zeroColor);
        if(shared.magnetTxt != null)
        {
            
            if (GameManager.NumMagnets == 0)
            {
                shared.magnetTxt.faceColor = shared.zeroColor;
            }
            else
            {
                shared.magnetTxt.faceColor = shared.originaleColor;
            }
            shared.magnetTxt.text = GameManager.NumMagnets.ToString();
        }
        if(shared.ventsTxt != null)
        {
            
            if (GameManager.NumVents == 0)
            {
                shared.ventsTxt.faceColor = shared.zeroColor;
            }
            else
            {
                shared.ventsTxt.faceColor = shared.originaleColor;
            }
            shared.ventsTxt.text = GameManager.NumVents.ToString();
        }
        if(shared.wallTxt != null)
        {
            
            if (GameManager.NumWalls == 0)
            {
                shared.wallTxt.faceColor = shared.zeroColor;
            }
            else
            {
                shared.wallTxt.faceColor = shared.originaleColor;
            }
            shared.wallTxt.text = GameManager.NumWalls.ToString();
        }
    }
}
