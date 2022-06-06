using System.Collections;
using System.Collections.Generic;
using gilad.Scripts;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddingItems : MonoBehaviour
{
    [SerializeField] private Vector2 itemsInitPos;

    [SerializeField] private GameObject wall; // item code = 1 
    [SerializeField] private GameObject ventilator; // item code = 3
    [SerializeField] private GameObject magnet; // item code = 2

    private static AddingItems shared;

    public static bool IsActive = true;

    // Start is called before the first frame update
    void Start()
    {
        shared = this;
        IsActive = true;
    }

    public void InstantiateItem(int itemCode)
    {
        // print("k");

        GameObject item = null;
        bool goodChoice = true;
        switch (itemCode)
        {
            case 1:
                if (GameManager.NumWalls-- > 0)
                {
                    item = wall;
                }
                else goodChoice = false;
                break;
            case 2:
                if (GameManager.NumMagnets-- > 0)
                {
                    item = magnet;
                }
                else goodChoice = false;
                break;
            case 3:
                if (GameManager.NumVents-- > 0)
                {
                    item = ventilator;
                }
                else goodChoice = false;
                break;
        }

        if (goodChoice)
        {
            Instantiate(item, Camera.main.WorldToScreenPoint(Input.mousePosition), quaternion.identity);
            // print(3);
            ValuesManager.UpdateQuants();

            if (GameManager.Level == 6 && ! TutorialManager.LeftClickTutorialDoneFlag) // todo update it after adding scenes 
            {
                GameObject.Find("Canvas").transform.Find("tutor L click").gameObject.GetComponent<TutorialManager>().LeftClickTutorialEnding();
                TutorialManager.LeftClickTutorialDoneFlag = true;
            }
            
            if (GameManager.Level == 7) // todo update it after adding scenes 
            {
                GameObject.Find("Canvas").transform.Find("tutor L click").gameObject.GetComponent<TutorialManager>().LastTutorEnding();
            }
        }

        if (!IsActive)
        {
            BallEitan.BallReset();
        }
    }

    private bool TryToTake(int itemCode)
    {
        return false;
    }

    public void ReloadScene()
    {
        HitAndReset.OnReset();
        SceneManager.LoadScene($"level {GameManager.Level}");
    }

    public static void Create(int code)
    {
        shared.InstantiateItem(code);
    }
}