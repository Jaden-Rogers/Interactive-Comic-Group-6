using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    // Offset between the camera and the target position
    private Vector3 offset = new Vector3(0f, 0f, -10f);

    // Time taken for camera to reach target position
    private float smoothTime = 0.25f;

    // velocity of camera movement, (initialized to zero)
    private Vector3 velocity = Vector3.zero;

    // Target to follow, can be set in Unity Editor
    [SerializeField] private Transform target;

    private void Update()
    {
        // Calculates the target position:Adds offset to target's position
        Vector3 targetPosition = target.position + offset;

        // Moves the camera at a smooth rate towards the target position using "Vector3.SmoothDamp"
        // This function interpolates between the current position and the target position over time
        // The "ref velocity" parameter is used to track the current velocity, which is modified by this function
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}