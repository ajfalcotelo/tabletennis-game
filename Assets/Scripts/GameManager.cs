using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI botScoreText;
    private int playerScore = 0;
    private int botScore = 0;
    private const string playerScoreKey = "PlayerScore";
    private const string botScoreKey = "BotScore";
    private static bool pointToPlayer;


    void Start()
    {
        playerScore = PlayerPrefs.GetInt(playerScoreKey, 0);
        botScore = PlayerPrefs.GetInt(botScoreKey, 0);
        UpdateScores(); 
    }


    public void AddPlayerScore()
    {
        playerScore++;
        PlayerPrefs.SetInt(playerScoreKey, playerScore);
        PlayerPrefs.Save();
        UpdateScores();
    }


    public void AddBotScore()
    {
        botScore++;
        PlayerPrefs.SetInt(botScoreKey, botScore);
        PlayerPrefs.Save();
        UpdateScores();
    }


    void UpdateScores()
    {
        playerScoreText.text = "Player Score:\n" + playerScore;
        botScoreText.text = "Bot Score:\n" + botScore;
    }
    

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey(playerScoreKey);
        PlayerPrefs.DeleteKey(botScoreKey);
        PlayerPrefs.Save();
    }


    public static void SetPointToPlayer(bool value)
    {
        pointToPlayer = value;
    }


    public static bool GetPointToPlayer()
    {
        return pointToPlayer;
    }
}
