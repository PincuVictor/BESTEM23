using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    private PlayerStats stats;
    private Timer attackTimer;
    private Timer attackDurationTimer;

    [SerializeField] private GameObject highAttack;
    [SerializeField] private GameObject lowAttack;


    void Awake()
    {
        stats = GetComponent<PlayerStats>();
        attackTimer = new Timer();
        attackDurationTimer = new Timer();
        attackTimer.Set(stats.AttackSpeed);
        attackDurationTimer.Set(stats.AttackDuration);
    }


    void Update()
    {
        attackTimer.Update();
        if (attackDurationTimer.Update())
        {
            //highAttack.SetActive(false);
            //lowAttack.SetActive(false);
        }
    }

    public void AttackHigh()
    {
        if (RemoveEnergy())
        {
            Debug.Log("HIGH ATTACK");
            //highAttack.SetActive(true);

        }

    }
    public void AttackLow()
    {
        if (RemoveEnergy())
        {
            Debug.Log("LOW ATTACK");
            //lowAttack.SetActive(true);
        }

    }

    public bool finishAttack()
    {
        return attackDurationTimer.HasEnded();
    }


    private bool RemoveEnergy()
    {
        if (stats.Energy > 1 && attackTimer.HasEnded() && attackDurationTimer.HasEnded())
        {
            stats.Energy -= 1;
            attackTimer.Reset();
            attackDurationTimer.Reset();
            return true;
        }
        return false;
    }


}
