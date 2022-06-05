using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static bool LeftClickTutorialDoneFlag = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     LeftClickTutorialEnding();
        // }
    }

    public void LeftClickTutorialEnding()
    {
        GetComponent<Animator>().SetBool("done", false);
    }
}
