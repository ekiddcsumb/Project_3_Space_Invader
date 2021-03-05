using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject hiScoreText;
    
    private int playerScore = 0;
    private int hiScore = 0;
    public void AddScore(int score)
    {
        playerScore += score;

        if (hiScore < playerScore)
        {
            hiScore = playerScore;
        }
    }

    private void Update()
    {
        if (playerScore < 10)
        {
            scoreText.GetComponent<Text>().text = "0" + "0" + "0" + playerScore;
        }
        else if (playerScore < 100)
        {
            scoreText.GetComponent<Text>().text = "0" + "0" + playerScore;
        }
        else if (playerScore < 1000)
        {
            scoreText.GetComponent<Text>().text = "0" + playerScore;
        }
        else
        {
            scoreText.GetComponent<Text>().text = playerScore.ToString();
        }
        
        if (hiScore < 10)
        {
            hiScoreText.GetComponent<Text>().text = "0" + "0" + "0" + hiScore;
        }
        else if (hiScore < 100)
        {
            hiScoreText.GetComponent<Text>().text = "0" + "0" + hiScore;
        }
        else if (hiScore < 1000)
        {
            hiScoreText.GetComponent<Text>().text = "0" + hiScore;
        }
        else
        {
            hiScoreText.GetComponent<Text>().text = hiScore.ToString();
        }
    }

    void StartGame()
    {
        
    }

    void EndGame()
    {
        playerScore = 0;
        hiScore = 0;
    }
}
