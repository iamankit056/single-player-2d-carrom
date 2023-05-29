using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PucksPicker : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Black Puck"))
            _gameManager.UpdateBotScore(5);

        if(other.CompareTag("White Puck"))
            _gameManager.UpdatePlayerScore(5);

        if(other.CompareTag("Red Puck"))
        {
            if(_gameManager.playerTurn)
                _gameManager.UpdatePlayerScore(10);
            else
                _gameManager.UpdateBotScore(10);
        }
        
    }    
}
