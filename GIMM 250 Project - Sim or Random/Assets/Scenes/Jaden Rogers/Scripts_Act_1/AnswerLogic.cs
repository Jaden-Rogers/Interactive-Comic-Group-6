using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerLogic : MonoBehaviour
{
    private NumberItem numItem;
    [SerializeField] private float answerNumber;
    public bool correctAnswer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if given a child object run GetChildObject
        if (transform.childCount > 0 && GetChildObject() == false)
        {
            GetChildObject();
        }
        if (transform.childCount > 0)
        {
            if (numItem.numberValue == answerNumber)
            {
                correctAnswer = true;
            }
            else
            {
                correctAnswer = false;
            }
        }
        else
        {
            correctAnswer = false;
        }
    }

    private bool GetChildObject()
    {
        numItem = GetComponentInChildren<NumberItem>();
        return true;
    }
}
