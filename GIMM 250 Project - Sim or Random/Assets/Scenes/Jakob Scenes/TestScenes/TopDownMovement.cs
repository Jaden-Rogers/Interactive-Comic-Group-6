﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{

    public float speed; // Speed given to attached object
    public Rigidbody2D rb; // Reference to the Rigidbody component, attached to the GameObject
    private Vector2 moveInput; // Vector to store input for movement
 
    void Update()
    {
        // Get the horizontal and vertical input from the player, left right up down keys
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Normalize the movement vector to ensure consistent speed in all directions
        moveInput.Normalize();

        // Set the velocity of the Rigidbody to move the object in the desired direction
        // Multiplied by the speed to control actual movement speed of attached object
        rb.velocity = moveInput * speed;
    }
}