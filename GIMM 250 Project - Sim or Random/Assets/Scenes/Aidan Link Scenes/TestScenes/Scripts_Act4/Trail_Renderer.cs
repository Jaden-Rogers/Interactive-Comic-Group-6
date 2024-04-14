using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    private TrailRenderer trail;

    void Start()
    {
        // Get the TrailRenderer component
        trail = GetComponent<TrailRenderer>();

        // Set up the trail
        trail.startWidth = 0.1f; // The width of the trail at the spawn point
        trail.endWidth = 0.0f; // The width of the trail at the end point
        trail.time = 1.0f; // The time it takes for the trail to fade out completely
    }
}
