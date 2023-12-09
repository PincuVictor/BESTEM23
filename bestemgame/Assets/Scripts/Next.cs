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
    private void Start()
    {
        if (text != null)
        {
            for (int i = 0; i < GameManager.managerInstance.index; ++i)
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
