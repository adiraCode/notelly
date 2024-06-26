using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MatchLogic : MonoBehaviour
{
    static MatchLogic Instance;

    public int maxPoints = 3;
    public TextMeshProUGUI pointsText;
    public GameObject quizButton;
    private int points = 0;

    private void Start()
    {
        Instance = this;
    }

    void UpdatePointsText()
    {
        pointsText.text = points + "/" + maxPoints;
        if(points == maxPoints ) 
        {
            pointsText.text = "Good Job!";
            quizButton.SetActive(true);            
        }
    }

    public static void AddPoint()
    {
        AddPoints(1);
    }
    public static void AddPoints(int points)
    {
        Instance.points += points;
        Instance.UpdatePointsText();
    }

}
