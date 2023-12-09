using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class GameManager : MonoBehaviour
{
        public TournamentAdder TournamentInfo;
        public static GameManager managerInstance;
        public int index = 0;
        public string[] PermanentInput = {"", "", "", "","", "", "", "","", "", "", "","", "", "", "", ""};
        public int[] TList = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        public void Awake()
        {
                if (managerInstance == null)
                        managerInstance = this;
                else
                        Destroy(gameObject);
                DontDestroyOnLoad(managerInstance);
        }

        public void Tournament()
        {
                TournamentInfo = FindObjectOfType<TournamentAdder>();
                int i;
                index = TournamentInfo.index;
                for (i = 0; i < index; ++i)
                {
                        TList[i] = TournamentInfo.TList[i];
                        PermanentInput[i] = TournamentInfo.PermanentInput[i];
                }
                SceneManager.LoadScene("GameScene");
                
        }
        public void ChangeScene( string scene )
        {
                SceneManager.LoadScene(scene);
        }
}
