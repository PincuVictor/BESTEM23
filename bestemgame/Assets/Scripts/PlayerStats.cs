using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int playerID;
    public string PlayerName = "Player";
    public TMP_Text nameText;
    public float MaxEnergy = 5.0f;
    public float EnergyRegen = 0.01f;
    public float Energy = 5.0f;

    public float AttackSpeed = 0.25f;
    public float AttackDuration = 0.25f;

    public float BlockSpeed = 0.25f;
    public float BlockDuration = 0.25f;

    public float MovementSpeed = 2f;

    private void Start()
    {
        if(playerID == 1)
            PlayerName = GameManager.managerInstance.GetPlayer1Name() != "" ? GameManager.managerInstance.GetPlayer1Name() : "Player" + playerID;
        if (playerID == 2)
            PlayerName = GameManager.managerInstance.GetPlayer2Name() != "" ? GameManager.managerInstance.GetPlayer2Name() : "Player" + playerID;
        nameText.text = PlayerName;
    }

    private void Update()
    {
        if(MaxEnergy > Energy)
        {
            Energy += EnergyRegen * Time.deltaTime;
        }
    }
}
