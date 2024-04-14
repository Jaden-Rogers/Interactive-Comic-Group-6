using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidanTopDownMovement : MonoBehaviour
{
    float speed = 300; // Speed given to attached object
    public Rigidbody2D rb; // Reference to the Rigidbody component, attached to the GameObject
    private Vector2 moveInput; // Vector to store input for movement
    private bool isMovingUp = true; // Flag to track direction of movement
    float speedIncreasePerSecond = 20; // Amount to increase speed by each second
    void Update()
    {
        // If the space bar is hit, toggle the direction of movement
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMovingUp = !isMovingUp;
        }

        // Set the direction of movement based on the isMovingUp flag
        moveInput.y = isMovingUp ? 1 : -1;

        speed += speedIncreasePerSecond * Time.deltaTime;

        // Set the velocity of the Rigidbody to move the object in the desired direction
        // Multiplied by the speed to control actual movement speed of attached object
        // We set the x component of the velocity to 0 to prevent horizontal movement
        rb.velocity = new Vector2(0, moveInput.y) * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    // Check if the object we collided with is a barrier
        if (collision.gameObject.tag == "Barrier")
        {
            // If it is, end the game
            EndGame();
        }
    }

    void EndGame()
    {
    // Here you can handle what happens when the game ends
    // For example, you might load a game over screen
    Debug.Log("Game Over");
    }
}
