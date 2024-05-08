using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class QuizManager : MonoBehaviour
{
    [SerializeField]
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    private int currentQuestion = 4;

    private int points = 0;

    public GameObject completeScreen;
    public GameObject failedScreen;
    public GameObject quizPanel;

    // public TextMeshProUGUI confirmTxt;
    public TextMeshProUGUI resultsTxtC;
    public TextMeshProUGUI resultsTxtF;
    public TextMeshProUGUI QuestionTxt;

    public void Start()
    {
        generateQuestion();
    }


    public void correct()
    {
        
        if (currentQuestion != 0)
        {
            QnA.RemoveAt(currentQuestion);
            currentQuestion--; // Decrement currentQuestion after removing the question
            generateQuestion();

        }
        
       
       // for (int i = 4; i == 0; i--)
        //{
           // if (i == 0)
            //{
        if(currentQuestion == 0) {
         if (points >= 3)
                {
                    completeScreen.SetActive(true);
                    quizPanel.SetActive(false);

                    resultsTxtC.text = points + " out of 5 correct";
                }
                else
                {
                    failedScreen.SetActive(true);
                    quizPanel.SetActive(false);

                    resultsTxtF.text = points + " out of 5 correct";
                }
        }
               
           // }
       // }
        /*
        if (options.GetComponent<AnswerScript>().isCorrect = true)
        {
            confirmTxt.text = "Correct";
        }
        else
        {
            confirmTxt.text = "Wrong";
        }
        */        
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (currentQuestion < QnA.Count)
        {
            Debug.Log(currentQuestion);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.LogError("No more questions available.");
            // You may want to handle this case appropriately, like showing a message to the user or resetting the quiz.
        }
    }

}
