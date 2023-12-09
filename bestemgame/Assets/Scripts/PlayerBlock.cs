using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    private PlayerStats stats;
    private Timer blockTimer;
    private Timer blockDurationTimer;

    [SerializeField] private GameObject highBlock;
    [SerializeField] private GameObject lowBlock;


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
        if (blockDurationTimer.Update())
        {
            highBlock.SetActive(false);
            lowBlock.SetActive(false);
        }

    }

    public void BlockHigh()
    {
        if (RemoveEnergy())
        {
            Debug.Log("HIGH BLOCK");
            highBlock.SetActive(true);

        }

    }
    public void BlockLow()
    {
        if (RemoveEnergy())
        {
            Debug.Log("LOW BLOCK");
            lowBlock.SetActive(true);
        }

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
