using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    // create an array of 6 bools to store the correct answers
    private bool[] correctAnswers = new bool[6];
    // create an array of 6 answerlogic objects to store the answer logic scripts
    private AnswerLogic[] answerLogics = new AnswerLogic[6];


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculateScore()
    {
        float score;
        int trueCount = 0;

        // find all answer logic objects in the scene
        answerLogics = FindObjectsOfType<AnswerLogic>();

        // loop through each answer logic object and check if the answer is correct
        for (int i = 0; i < answerLogics.Length; i++)
        {
            if (answerLogics[i].correctAnswer)
            {
                trueCount++;
            }
        }
        // calculate the score based on the number of correct answers
        score = (float)trueCount / 6 * 100;
        Debug.Log("Score: " + score);

    }
}
