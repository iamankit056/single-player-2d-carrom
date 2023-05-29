using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    /*-----------------------------------------------------------------------
     |  All serialize field private variavles
     *----------------------------------------------------------------------*/
    [SerializeField] private TextMeshProUGUI _timerBar;
    [SerializeField] private TextMeshProUGUI _botScoreBar;
    [SerializeField] private TextMeshProUGUI _playerScoreBar;
    [SerializeField] private GameObject _botStriker;
    [SerializeField] private GameObject _playerStriker;

    /*-----------------------------------------------------------------------
     |  All private variables 
     *----------------------------------------------------------------------*/
    private int _botScore = 0;
    private int _playerScore = 0;
    private int timeMM = 4;
    private int timeSS = 60;
    private int _totalActivePucks = 19;

    /*-----------------------------------------------------------------------
     |  All constants are defined here
     *----------------------------------------------------------------------*/
    private const int TOTAL_PUCKS = 19;

    /*-----------------------------------------------------------------------
     |  All public variable 
     *----------------------------------------------------------------------*/
    public bool playerTurn = true;
    public bool gameover = false;

    /*-----------------------------------------------------------------------
     |  Unity predefined methods
     *----------------------------------------------------------------------*/
    private void Start() 
    {
        InitialSetup();
    }

    private void Update() 
    {
        if(gameover || _totalActivePucks <= 0)
            Gameover();    
    }

    /*-----------------------------------------------------------------------
     |  my defined methods
     *----------------------------------------------------------------------*/
    private void InitialSetup()
    {
        gameover = false;

        UpdateBotScore();
        UpdatePlayerScore();  

        InvokeRepeating("StartCountDown", 0.0f, 1.0f); 
    }

    private void Gameover()
    {

    }

    private void GameRestart()
    {

    }

    private void StartCountDown() 
    {
        timeSS -= 1;

        if(timeSS <= 0)
        {
                timeMM -= 1;
                timeSS = 60;
        }
        else if(timeMM <= 0 && timeSS <= 0)
        {
            gameover = true;
            CancelInvoke();
        }

        _timerBar.text = "0" + timeMM + ":" + timeSS; 
    }

    public void UpdateBotScore(int value=0)
    {
        if(value == 0)
        {
            _botScore = 0;
            _totalActivePucks -= 1;
            _botScoreBar.text = _botScore.ToString();
        }
        else
        {
            _botScore += value;
            _totalActivePucks -= 1;
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
