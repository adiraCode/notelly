using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false; // bool used to determine the correct answer
    public QuizManager quizManager; // Instance of QuizManager script

    public Color startColor; // Initial color for answer buttons

    public void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    public void Answer()
    {        
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");
            quizManager.wrong();
        }
    }
}
