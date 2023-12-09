using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string PlayerName = "Player";
    public float MaxEnergy = 5.0f;
    public float EnergyRegen = 0.01f;
    public float Energy = 5.0f;

    public float AttackSpeed = 0.25f;
    public float AttackDuration = 0.25f;

    public float BlockSpeed = 0.25f;
    public float BlockDuration = 0.25f;

    public float MovementSpeed = 2f;

    private void Update()
    {
        if(MaxEnergy > Energy)
        {
            Energy += EnergyRegen * Time.deltaTime;
        }
    }
}
