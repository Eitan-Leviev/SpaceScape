using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace gilad.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static int Level = 1;

        private static GameManager shared;

        private LinkedList<GameObject> Hits = new LinkedList<GameObject>();

        [SerializeField] private GameObject hittEffectInst;

        [SerializeField] private int numWalls = 3;

        [SerializeField] private int numMagnets = 3;

        [SerializeField] private int numVents = 3;

        [SerializeField] private GameObject transition;

        private int _numTries = 1;

        public static int NumTries
        {
            get => shared._numTries;
            set
            {
                shared._numTries = value;
                // ValuesManager.UpdateQuants();
            }
        }


        public static int NumWalls
        {
            get => shared.numWalls;
            set => shared.numWalls = Math.Max(value, 0);
        }

        public static int NumMagnets
        {
            get => shared.numMagnets;
            set => shared.numMagnets = Math.Max(value, 0);
        }

        public static int NumVents
        {
            get => shared.numVents;
            set => shared.numVents = Math.Max(value, 0);
        }
        // Start is called before the first frame update

        private void Awake()
        {
            var curSceneName = SceneManager.GetActiveScene().name;
            var curLevelString = curSceneName.Substring(6, curSceneName.Length - 6); // given "level 122323" we take "122323"
            var curLevelNum = Int32.Parse(curLevelString);
            Level = curLevelNum;
            shared = this;
        }

        void Start()
        {
            HitEffect.Hits = Hits;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (SceneManager.GetActiveScene().name == "Ending")
                {
                    return;
                }
                Time.timeScale = 1;
                Level++;
                Scenes.LoadCurrLevel();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (Level == 1)
                {
                    return;
                }
                Time.timeScale = 1;
                Level--;
                Scenes.LoadCurrLevel();
            }
        }

        public static void PlaceHit(Vector3 pos)
        {
            if (shared.Hits.Count == 0)
            {
                // print(1);
                Instantiate(shared.hittEffectInst, pos, Quaternion.identity);
            }
            else
            {
                // print(2);
                var nextHit = shared.Hits.Last.Value;
                nextHit.transform.position = pos;
                shared.Hits.RemoveLast();
                nextHit.SetActive(true);
            }
        }

        public static void WinLevel()
        {
            Instantiate(shared.transition, Vector3.back * 2, Quaternion.identity);
        }
    }
}