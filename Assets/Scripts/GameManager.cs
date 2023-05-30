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
    [SerializeField] private GameObject _arrangedPucks;
    [SerializeField] private GameObject _gameoverBoard;
    [SerializeField] private TextMeshProUGUI _winnerBoard;

    /*-----------------------------------------------------------------------
     |  All private variables 
     *----------------------------------------------------------------------*/
    private int _botScore = 0;
    private int _playerScore = 0;
    private int timeMM = 0;
    private int timeSS = 0;
    private int _totalActivePucks;

    /*-----------------------------------------------------------------------
     |  All constants are defined here
     *----------------------------------------------------------------------*/
    private const int TOTAL_PUCKS = 19;
    private const int TOTAL_TIME = 5;

    /*-----------------------------------------------------------------------
     |  All public variable 
     *----------------------------------------------------------------------*/
    public bool playerTurn = true;
    public bool gameover = false;
    public bool gameStarted = true;

    /*-----------------------------------------------------------------------
     |  Unity predefined methods
     *----------------------------------------------------------------------*/
    private void Start() 
    {
        InitialSetup();
    }

    private void Update() 
    {
        if(gameover || _totalActivePucks <= 0 && gameStarted)
            Gameover();    
    }

    /*-----------------------------------------------------------------------
     |  my defined methods
     *----------------------------------------------------------------------*/
    private void InitialSetup()
    {
        gameover = false;
        gameStarted = true;
        playerTurn = true;
        
        timeMM = TOTAL_TIME;
        _totalActivePucks = TOTAL_PUCKS;

        UpdateBotScore();
        UpdatePlayerScore();  

        Instantiate(_playerStriker);
        Instantiate(_arrangedPucks);

        InvokeRepeating("StartCountDown", 0.0f, 1.0f); 
    }

    public void Gameover()
    {
        gameStarted = false;
        CancelInvoke();
        
        if(_playerScore == _botScore)
            _winnerBoard.text = "Draw";
        else if(_playerScore > _botScore)
            _winnerBoard.text = "You Win";
        else
            _winnerBoard.text = "You Loss";

        _gameoverBoard.SetActive(true);
    }

    public void GameRestart()
    {
        DestroyAllPucksAndStriker();
        _gameoverBoard.SetActive(false);
        InitialSetup();
    }

    private void DestroyAllPucksAndStriker()
    {
        Destroy(GameObject.FindGameObjectWithTag("Pucks"));
        Destroy(GameObject.FindGameObjectWithTag("Striker"));
    }

    private void StartCountDown() 
    {
        timeSS -= 1;

        if(timeSS < 0)
        {
                timeMM -= 1;
                timeSS = 60;
        }
        else if(timeMM <= 0 && timeSS <= 0) {
            gameover = true;
        }

        _timerBar.text = "0" + timeMM + ":" + ((timeSS < 10) ? '0' + timeSS.ToString() : timeSS.ToString()); 
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
        playerTurn = !playerTurn;

        if(playerTurn)
            Instantiate(_playerStriker);
        else 
            Instantiate(_botStriker);
    }
}
