using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetHit : MonoBehaviour
{
    public int player;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "attack")
        {
            GameManager.managerInstance.KillPlayer(player);
        }
    }
}
