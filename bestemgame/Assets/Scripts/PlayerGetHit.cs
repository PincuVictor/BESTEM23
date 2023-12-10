using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetHit : MonoBehaviour
{
    public Player player;
    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.tag == "attack")
        {
            //GameManager.managerInstance.KillPlayer(player);
            player.state = Player.PlayerStates.die;

            
        }
    }
}
