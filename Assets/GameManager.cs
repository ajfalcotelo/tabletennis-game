using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int playerScore = 0;
    private const string ScoreKey = "Score";

    public TextMeshProUGUI playerScoreText;

    void Start()
    {
        playerScore = PlayerPrefs.GetInt(ScoreKey, 0);
        UpdateScores(); 
    }


    public void AddPlayerScore()
    {
        playerScore++;
        PlayerPrefs.SetInt(ScoreKey, playerScore);
        PlayerPrefs.Save();
        UpdateScores();
    }


    void UpdateScores()
    {
        playerScoreText.text = "Player Score: " + playerScore;
    }
    

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey(ScoreKey);
        PlayerPrefs.Save();
    }

}
