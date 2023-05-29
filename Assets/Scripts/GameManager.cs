using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _botScoreBar;
    [SerializeField] private TextMeshProUGUI _playerScoreBar;
    [SerializeField] private GameObject _botStriker;
    [SerializeField] private GameObject _playerStriker;

    private int _botScore = 0;
    private int _playerScore = 0;

    public bool playerTurn = true;
    public bool gameover = true;

    private void Start() 
    {
        gameover = false;

        UpdateBotScore();
        UpdatePlayerScore();    
    }

    public void UpdateBotScore(int value=0)
    {
        if(value == 0)
        {
            _botScore = 0;
            _botScoreBar.text = _botScore.ToString();
        }
        else
        {
            _botScore += value;
            _botScoreBar.text = _botScore.ToString();
        }
    }
    
    public void UpdatePlayerScore(int value=0)
    {
        if(value == 0)
        {
            _playerScore = 0;
            _playerScoreBar.text = _playerScore.ToString();
        }
        else
        {
            _playerScore += value;
            _playerScoreBar.text = _playerScore.ToString();
        }
    }

    public void ChangeTurn()
    {
        if(playerTurn)
        {
            _botStriker.SetActive(playerTurn);
            _playerStriker.SetActive(!playerTurn);
        }

        playerTurn = !playerTurn;
    }
}
