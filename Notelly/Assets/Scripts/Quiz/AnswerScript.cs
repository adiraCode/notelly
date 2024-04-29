using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;


// public GameObject levelCompleteUI;
// public GameObject levelFailedUI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    private int points;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.correct();
            points = points + 1;
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.correct();
        }

    }

    /*
    if(points => 3 ) 
        {
            pointsText.text = "Good Job!";
            quizButton.SetActive(true);            
        }
    */
}
