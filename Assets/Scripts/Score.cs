using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int currentScore;
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }
    public int GetCurrentScore()
    {
        scoreText.text = currentScore.ToString();
        return currentScore;
    }
    public void IncreaseCurrentScore(int increaseScore)
    {
        currentScore += increaseScore;
        GetCurrentScore();
    }
    public void ReduceCurrentScore(int reduceScore)
    {
        currentScore -= currentScore;
        GetCurrentScore();
    }
}
