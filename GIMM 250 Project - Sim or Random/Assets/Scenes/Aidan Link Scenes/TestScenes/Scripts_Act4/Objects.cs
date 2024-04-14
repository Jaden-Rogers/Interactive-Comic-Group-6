using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public float speed = 5f; // Speed at which the object moves

    // Update is called once per frame
    void Update()
    {
        // Move the object from right to left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // If the object has moved off the left side of the screen, destroy it
        if (transform.position.x < -30) // Adjust this value based on your needs
        {
            Destroy(gameObject);
        }
    }
}
