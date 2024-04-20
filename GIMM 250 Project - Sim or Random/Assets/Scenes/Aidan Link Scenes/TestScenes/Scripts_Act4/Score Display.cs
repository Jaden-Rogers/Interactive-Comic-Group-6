using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // UI element
    public float score; //score
    public bool isRunning = true; //timer is running or not

    void Update()
    {
        if (isRunning == true)
        {
            // Increase the time by the time passed since the last frame
            score += Time.deltaTime;
            Debug.Log(isRunning);

            // Update the text element with the current time
            scoreText.text = Mathf.Round(score).ToString();
        }
    }
}
