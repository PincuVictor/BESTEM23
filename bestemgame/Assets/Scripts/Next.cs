using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = System.Object;

public class Next : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text[] textBrackets;
    private void Start()
    {
        int i;
        if (textBrackets != null)
        {
            for (i = 0; i <= 7; ++i)
            {
                if (GameManager.managerInstance.TList[i] != -1) 
                    textBrackets[i].text = GameManager.managerInstance.PermanentInput[GameManager.managerInstance.TList[i]];
                else 
                    textBrackets[i].text = "-";
            }
        }
        if (text != null)
        {
            for (i = 0; i < GameManager.managerInstance.index; ++i)
            {
                if (GameManager.managerInstance.TList[i] != -1)
                {
                    text.text = GameManager.managerInstance.PermanentInput[GameManager.managerInstance.TList[i]] + " is the winner!";
                    break;
                }
            }
        }
    }

    public void OnClickMenu()
    {
        GameManager.managerInstance.ChangeScene("MenuScene");
    }
    public void OnClickNextRound()
    {
            GameManager.managerInstance.NewRound();

    }
}
