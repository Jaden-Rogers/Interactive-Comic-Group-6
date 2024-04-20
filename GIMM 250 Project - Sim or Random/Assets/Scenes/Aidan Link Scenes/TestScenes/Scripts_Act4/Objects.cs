using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public float speed = 5f; // Speed of object
    public float rotationSpeed = 20f; // object rotation

    void Update()
    {
        //Moves object from the right to the left
        transform.position += Vector3.left * speed * Time.deltaTime;

        //Rotates the object
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        //Destroys object when it goes off screen
        if (transform.position.x < -30)
        {
            Destroy(gameObject);
        }
    }
}
