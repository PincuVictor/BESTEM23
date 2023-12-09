using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 velocity;
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

    }

    public void Move(Vector2 vel)
    {
        velocity.x = vel.x;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }
    
}
