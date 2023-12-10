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

    public AudioSource audioSource;
    public AudioClip attackSound;
    public AudioClip blockSound;


    [SerializeField] Animator anim;
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
    private bool allreadyAttacked = false;
    private bool allreadyBlocked = false;



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
                anim.SetBool("isWalking", false);
                anim.SetTrigger("endAttack");
                anim.SetTrigger("endBlock");
                if (Input.GetKey(left) || Input.GetKey(right))
                    state = PlayerStates.walking;

                if (Input.GetKey(attackLow) || Input.GetKey(attackHigh))
                    state = PlayerStates.attacking;

                if (Input.GetKey(blockLow) || Input.GetKey(blockHigh))
                    state = PlayerStates.blocking;


                break;


            case PlayerStates.walking:
                anim.SetBool("isWalking", true);
                anim.SetTrigger("endAttack");
                anim.SetTrigger("endBlock");
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

                if (Input.GetKey(attackHigh) && !allreadyAttacked)
                {
                    if (attacks.AttackHigh())
                    {
                        anim.SetTrigger("attackHigh");
                        allreadyAttacked = true;
                        audioSource.clip = attackSound;
                        audioSource.volume = 1f;
                        audioSource.Play();
                    }
                }

                if (Input.GetKey(attackLow) && !allreadyAttacked)
                {
                    if (attacks.AttackLow())
                    {
                        anim.SetTrigger("attackLow");
                        allreadyAttacked = true;
                        audioSource.clip = attackSound;
                        audioSource.volume = 1f;
                        audioSource.Play();
                    }
                }

                if (attacks.finishAttack())
                {
                     allreadyAttacked = false;
                    anim.SetTrigger("endAttack");
                    state = PlayerStates.idle;
                }

                break;


            case PlayerStates.blocking:
                velocity.x = 0;
                movement.Move(velocity);

                if (Input.GetKey(blockHigh) && !allreadyBlocked)
                {
                    if (block.BlockHigh())
                    {
                        anim.SetTrigger("blockHigh");
                        allreadyBlocked = true;
                        audioSource.clip = blockSound;
                        audioSource.volume = 0.5f;
                        audioSource.Play();
                    }
                }

                if (Input.GetKey(blockLow) && !allreadyBlocked)
                {
                    if (block.BlockLow())
                    {
                        anim.SetTrigger("blockLow");
                        allreadyBlocked = true;
                        audioSource.clip = blockSound;
                        audioSource.volume = 0.5f;
                        audioSource.Play();

                    }
                }

                if (block.finishBlocking())
                {
                    allreadyBlocked = false;
                    anim.SetTrigger("endBlock");
                    state = PlayerStates.idle;
                }


                break;


            case PlayerStates.die:
                velocity.x = 0;
                movement.Move(velocity);
                anim.SetTrigger("isDead");
                movement.enabled = false;
                attacks.enabled = false;
                block.enabled = false;
                break;
        
        }
    }

}

