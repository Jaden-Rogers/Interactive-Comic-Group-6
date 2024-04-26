using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AidanTopDownMovement : MonoBehaviour
{
    float speed = 300; // Speed given to attached object
    float speed1 = 600;
    public Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isMovingUp = true;
    float speedIncreasePerSecond = 10; //Speed increase per second
    float rotationSpeed = 180f; // Rotation speed in degrees per second

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //If space is pressed, change direction
        {
            isMovingUp = !isMovingUp;
        }

        moveInput.y = isMovingUp ? 1 : -1; // Set moveInput.y to 1 if isMovingUp is true, otherwise set it to -1

        speed += speedIncreasePerSecond * Time.deltaTime; //Speed increasing

        rb.velocity = new Vector2(0, moveInput.y) * speed; //Move object

        rb.velocity = new Vector2(speed, moveInput.y * speed1); //Move object

        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime); //Rotate player
    }

    void OnCollisionEnter2D(Collision2D collision) //Function to detect collision with enemy
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EndGame();

            ScoreDisplay scoreDisplay = GetComponent<ScoreDisplay>();

            // If the ScoreDisplay script is found, stop the timer
            if (scoreDisplay != null)
            {
                scoreDisplay.isRunning = false;

                PlayerPrefs.SetFloat("Score", scoreDisplay.score); // Save the score to the PlayerPrefs
            }
        }
    }
    void EndGame()
    {
        Debug.Log("Game Over"); //Debug message to console
        SceneManager.LoadScene("Aidan End Menu"); //Load EndScreen scene
        rb.constraints = RigidbodyConstraints2D.FreezePosition; //Freeze player position

    }

    public void MovePlayer()
    {   
            isMovingUp = !isMovingUp;
    }
}
