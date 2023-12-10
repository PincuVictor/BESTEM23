using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    private PlayerStats stats;
    private Timer blockTimer;
    private Timer blockDurationTimer;

    [SerializeField] private GameObject highHitbox;
    [SerializeField] private GameObject lowHitbox;


    void Awake()
    {
        stats = GetComponent<PlayerStats>();
        blockTimer = new Timer();
        blockDurationTimer = new Timer();
        blockTimer.Set(stats.BlockSpeed);
        blockDurationTimer.Set(stats.BlockDuration);
    }


    void Update()
    {

        blockTimer.Update();
        blockDurationTimer.Update();

        if (blockDurationTimer.HasEnded())
        {
            highHitbox.SetActive(true);
            lowHitbox.SetActive(true);
        }

    }

    public bool BlockHigh()
    {
        if (RemoveEnergy())
        {
            Debug.Log("HIGH BLOCK");
            highHitbox.SetActive(false);
            return true;
        }
        return false;
    }
    public bool BlockLow()
    {
        if (RemoveEnergy())
        {
            Debug.Log("LOW BLOCK");
            lowHitbox.SetActive(false);
            return true;
        }
        return false;
    }

    public bool finishBlocking()
    {

        return blockDurationTimer.HasEnded();
    }


    private bool RemoveEnergy()
    {
        if (stats.Energy > 1 && blockTimer.HasEnded() && blockDurationTimer.HasEnded())
        {
            stats.Energy -= 1;
            blockTimer.Reset();
            blockDurationTimer.Reset();
            return true;
        }
        return false;
    }

}
