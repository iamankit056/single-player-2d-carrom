using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PucksPicker : MonoBehaviour
{
    /*-----------------------------------------------------------------------
     |  All serialize field private variavles
     *----------------------------------------------------------------------*/
    [SerializeField] GameManager _gameManager;

    /*-----------------------------------------------------------------------
     |  Unity predefined methods
     *----------------------------------------------------------------------*/
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Black Puck"))
        {
            Destroy(other.gameObject);
            _gameManager.UpdateBotScore(5);
        }

        if(other.gameObject.CompareTag("White Puck"))
        {
            Destroy(other.gameObject);
            _gameManager.UpdatePlayerScore(5);
        }

        if(other.gameObject.CompareTag("Red Puck"))
        {
            Destroy(other.gameObject);

            if(_gameManager.playerTurn)
                _gameManager.UpdatePlayerScore(10);
            else
                _gameManager.UpdateBotScore(10);
        }
        
    }    
}
