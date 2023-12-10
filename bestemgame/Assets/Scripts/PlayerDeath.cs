using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Timer timeUntilDeath;
    [SerializeField]private PlayerStats stats;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        timeUntilDeath = new Timer();
        timeUntilDeath.Set(5);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeUntilDeath.Update())
        {
            GameManager.managerInstance.KillPlayer(stats.playerID);
        }
        
    }
}
