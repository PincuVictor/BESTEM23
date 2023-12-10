using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TournamentAdder TournamentInfo;
    public static GameManager managerInstance;
    public int Round = 0;
    public int index = 0;
    public string[] PermanentInput = {"", "", "", "","", "", "", "","", "", "", "","", "", "", "", ""};
    public int[] TList = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};



    public int currentPlayer1IndexInList = 0;
    public int currentPlayer2IndexInList = 0;

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

        currentPlayer1IndexInList = 0;
        currentPlayer2IndexInList = 1;

        SceneManager.LoadScene("GameScene");
                
    }
    public void ChangeScene( string scene )
    {
            SceneManager.LoadScene(scene);
    }

    public void KillPlayer(int player)
    {
        if(player == 1)
        {
            TList[currentPlayer1IndexInList] = -1;
            Debug.Log("Eliminat" + currentPlayer1IndexInList);
        }else if(player == 2)
        {
            TList[currentPlayer2IndexInList] = -1;
            Debug.Log("Eliminat" + currentPlayer2IndexInList);
        }
        SceneManager.LoadScene("IntermissionScene");
    }
    public string GetPlayer1Name()
    {
        return PermanentInput[TList[currentPlayer1IndexInList]];
    }

    public string GetPlayer2Name()
    {
        return PermanentInput[TList[currentPlayer2IndexInList]];
    }

    public void NewRound()
    {
        List<int> players = new List<int>();
        if (managerInstance.Round == 0)
        {
            currentPlayer1IndexInList = 0;
            currentPlayer2IndexInList = 1;
            managerInstance.Round++;
            SceneManager.LoadScene("GameScene");
        }
        else
        {
                
            for (int i = currentPlayer2IndexInList+1; i < TList.Length; i++)
            {
                if (TList[i] != -1)
                {
                    players.Add(i);
                }
                if (players.Count >= 2)
                    break;
            }

            if(players.Count != 2)
            {
                for (int i = 0; i < currentPlayer2IndexInList + 1; i++)
                {
                    if (TList[i] != -1)
                    {
                        players.Add(i);
                    }
                    if (players.Count >= 2)
                        break;
                }
            }

            if (players.Count == 1)
            {
                SceneManager.LoadScene("WinnerScene");
            }
            else
            {
                currentPlayer1IndexInList = players[0];
                currentPlayer2IndexInList = players[1];
                SceneManager.LoadScene("GameScene");
            }




        }
    }
}
