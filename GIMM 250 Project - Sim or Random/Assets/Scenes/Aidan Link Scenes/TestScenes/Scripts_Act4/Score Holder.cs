using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import the TMPro namespace

public class ScoreHolder : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // UI element to display the score

    void Start()
    {
        // Retrieve the score value
        float score = PlayerPrefs.GetFloat("Score", 0);

        // Set the text of the TextMeshProUGUI element to the score value
        scoreText.text = "Score: " + score.ToString("F2");
    }
}
