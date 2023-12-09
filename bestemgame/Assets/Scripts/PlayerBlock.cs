using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    private PlayerStats stats;
    private Timer blockTimer;

    [SerializeField] private GameObject highBlock;
    [SerializeField] private GameObject lowBlock;


    void Awake()
    {
        stats = GetComponent<PlayerStats>();
        blockTimer = new Timer();
        blockTimer.Set(stats.BlockSpeed);
    }


    void Update()
    {
        if (blockTimer.Update())
        {
            highBlock.SetActive(false);
            lowBlock.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            BlockHigh();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            BlockLow();
        }

    }

    private void BlockHigh()
    {
        if (RemoveEnergy())
        {
            Debug.Log("HIGH BLOCK");
            highBlock.SetActive(true);

        }

    }
    private void BlockLow()
    {
        if (RemoveEnergy())
        {
            Debug.Log("LOW BLOCK");
            lowBlock.SetActive(true);
        }

    }


    private bool RemoveEnergy()
    {
        if (stats.Energy > 1 && blockTimer.HasEnded())
        {
            stats.Energy -= 1;
            blockTimer.Reset();
            return true;
        }
        return false;
    }

}
