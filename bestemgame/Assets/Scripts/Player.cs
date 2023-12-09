using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStats stats;
    public PlayerMovement movement;
    public PlayerAttacks attacks;
    public PlayerBlock block;
    public PlayerStates state;


    [SerializeField] private String left;
    [SerializeField] private String right;
    [SerializeField] private String attackHigh;
    [SerializeField] private String attackLow;
    [SerializeField] private String blockHigh;
    [SerializeField] private String blockLow;
    Vector2 velocity = Vector2.zero;
    public enum PlayerStates
    {
        idle,
        walking,
        attacking,
        blocking,
        die
    }


    private void Update()
    {
        velocity.x = 0f;

        if (Input.GetKey(left))
        {
            velocity.x = -2f;
        }
        if (Input.GetKey(right))
        {
            velocity.x = 2f;
        }



        switch (state)
        {
            case PlayerStates.idle:

                if (Input.GetKey(left) || Input.GetKey(right))
                    state = PlayerStates.walking;

                if (Input.GetKey(attackLow) || Input.GetKey(attackHigh))
                    state = PlayerStates.attacking;

                if (Input.GetKey(blockLow) || Input.GetKey(blockHigh))
                    state = PlayerStates.blocking;


                break;


            case PlayerStates.walking:


                movement.Move(velocity);

                if (velocity.x == 0)
                    state = PlayerStates.idle;

                if (Input.GetKey(left) || Input.GetKey(right))
                    state = PlayerStates.walking;

                if (Input.GetKey(attackLow) || Input.GetKey(attackHigh))
                    state = PlayerStates.attacking;

                if (Input.GetKey(blockLow) || Input.GetKey(blockHigh))
                    state = PlayerStates.blocking;

                break;


            case PlayerStates.attacking:
                velocity.x = 0f;
                movement.Move(velocity);

                if (Input.GetKey(attackHigh))
                {
                    attacks.AttackHigh();
                }

                if (Input.GetKey(attackLow))
                {
                    attacks.AttackLow();
                }

                if (attacks.finishAttack())
                {
                    state = PlayerStates.idle;
                }

                break;


            case PlayerStates.blocking:
                velocity.x = 0;
                movement.Move(velocity);

                if (Input.GetKey(blockHigh))
                {
                    block.BlockHigh();
                }

                if (Input.GetKey(blockLow))
                {
                    block.BlockLow();
                }

                if (block.finishBlocking())
                {
                    state = PlayerStates.idle;
                }


                break;


            case PlayerStates.die:
                movement.enabled = false;
                attacks.enabled = false;
                block.enabled = false;
                break;
        
        }
    }

}

