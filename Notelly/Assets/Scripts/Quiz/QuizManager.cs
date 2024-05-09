using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class QuizManager : MonoBehaviour
{
    [SerializeField]
    public List<QuestionAndAnswers> QnA; // List from QuestionsAndAnswers
    public GameObject[] options; // Array for answer options
    private int currentQuestion = 4; // Current question element

    public int score; // Track score

    public GameObject completeScreen; // Results screen for success
    public GameObject failedScreen; // Results screen for failure
    public GameObject quizPanel;

    public TextMeshProUGUI resultsTxtC; // Displays correct answer ratio
    public TextMeshProUGUI resultsTxtF; // Displays correct answer ratio
    public TextMeshProUGUI QuestionTxt; // Displays question text

    public AnswerScript AnswerScript;

    public void Start()
    {
        // Debug.Log("currentQuestion: " + currentQuestion);
        // Debug.Log("questionCount: " + questionCount);
        generateQuestion();
    }

    public void GameOver()
    {
        Debug.Log("Final score: " + score);

        if (score >= 3)
        {
            completeScreen.SetActive(true);
            quizPanel.SetActive(false);

            resultsTxtC.text = score + " out of 5 correct";
        }
        else
        {
            failedScreen.SetActive(true);
            quizPanel.SetActive(false);

            resultsTxtF.text = score + " out of 5 correct";
        }
    }

    public void correct()
    {
        score += 1; // Increment score by 1
        QnA.RemoveAt(currentQuestion); // Removes current question to prevent reoccurance
        currentQuestion--; // Decrement currentQuestion after removing the question
        StartCoroutine(WaitForNext()); // Buffer between questions
        // generateQuestion(); // Grab the next question
        /*
        if (currentQuestion != 0)
        {
            QnA.RemoveAt(currentQuestion); // Removes current question to prevent reoccurance
            currentQuestion--; // Decrement currentQuestion after removing the question
            generateQuestion();
        }*/
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion); // Removes current question to prevent reoccurance
        currentQuestion--; // Decrement currentQuestion after removing the question
        StartCoroutine(WaitForNext()); // Buffer between questions
        // generateQuestion(); // Grab the next question
    }

    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion(); // Grab the next question
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        Debug.Log("QnA.Count: " + QnA.Count);

        if (QnA.Count > 0)
        {
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.LogError("No more questions available.");
            GameOver();
        }
    }
}
