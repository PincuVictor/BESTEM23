using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    private PlayerStats stats;
    private Timer attackTimer;

    [SerializeField] private GameObject highAttack;
    [SerializeField] private GameObject lowAttack;


    void Awake()
    {
        stats = GetComponent<PlayerStats>();
        attackTimer = new Timer();
        attackTimer.Set(stats.AttackSpeed);
    }


    void Update()
    {
        if (attackTimer.Update())
        {
            highAttack.SetActive(false);
            lowAttack.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            AttackHigh();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AttackLow();
        }

    }

    private void AttackHigh()
    {
        if (RemoveEnergy())
        {
            Debug.Log("HIGH ATTACK");
            highAttack.SetActive(true);

        }

    }
    private void AttackLow()
    {
        if (RemoveEnergy())
        {
            Debug.Log("LOW ATTACK");
            lowAttack.SetActive(true);
        }

    }




    private bool RemoveEnergy()
    {
        if (stats.Energy > 1 && attackTimer.HasEnded())
        {
            stats.Energy -= 1;
            attackTimer.Reset();
            return true;
        }
        return false;
    }


}
