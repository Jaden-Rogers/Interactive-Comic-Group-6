using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public Transform target; // The target the camera should follow
    public float yPosition; // The y position to lock the camera at
    public float zPosition; // The z position to lock the camera at

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            // Slides on the x axis and locks y and z
            transform.position = new Vector3(target.position.x, yPosition, zPosition);
        }
    }
}
