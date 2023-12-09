using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 velocity;
    [SerializeField] private String left;
    [SerializeField] private String right;
    private bool movingLeft, movingRight;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        velocity.x = 0f;
        velocity.y = 0f;
    }

    private void Update()
    {
        if( Input.GetKeyDown(left) )
        {
            velocity.x += -2f;
        }
        if( Input.GetKeyUp(left) )
        {
            velocity.x += 2f;
        }
        if( Input.GetKeyDown(right) )
        {
            velocity.x += 2f;
        }
        if( Input.GetKeyUp(right) )
        {
            velocity.x += -2f;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }
    
}
