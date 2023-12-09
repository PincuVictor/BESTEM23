using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class TournamentAdder : MonoBehaviour
{
    [SerializeField] private Button[] btn;
    [SerializeField] private TMP_InputField[] inp;
    [SerializeField] private TMP_Text total;
    public string[] PermanentInput = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""};
    public int[] TList = {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
    public int index;

    public void NewPlayer()
    {
        btn[index].gameObject.SetActive(false);
        if (index < 7 )
        {
            btn[index + 1].gameObject.SetActive(true);
        }

        inp[index].gameObject.SetActive(true);
        index++;
        total.text = "Total Players: " + index;
    }

    public void StartTournament()
    {
        int i, j, num;
        Random rnd = new Random();
        for (i = 0; i < index; ++i)
            PermanentInput[i] = inp[i].text;
        for (i = 0; i < index; ++i)
        {
            bool unique = true;
            num = rnd.Next(index);
            for(j = 0; j < index; ++j )
                if (num == TList[j])
                    unique = false;
            if (unique)
                TList[i] = num;
            else
                i--;
        }
        GameManager.managerInstance.Tournament();
        
    }

}
