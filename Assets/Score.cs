using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    int score = 0;
    Text scoreText;

    void Start()
    {
        GameObject.Find("high").GetComponent<Text>().text = "HIGH SCORE: " + SCORE.HIGH_SCORE.ToString();
        scoreText = GetComponent<Text>();

    }
    public void AddScore(int _score)
    {
        score += _score;
        scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        if(score > SCORE.HIGH_SCORE) SCORE.HIGH_SCORE = score;
        return score;
    }
}




public static class SCORE
{
    public static int HIGH_SCORE = 0;
} 