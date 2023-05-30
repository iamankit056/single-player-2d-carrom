using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotStriker : MonoBehaviour
{
    /*-----------------------------------------------------------------------
     |  All serialize field private variavles
     *----------------------------------------------------------------------*/
    [SerializeField] private GameManager _gameManager;

    /*-----------------------------------------------------------------------
     |  All private variables 
     *----------------------------------------------------------------------*/
    private Rigidbody2D _strikerRb2D;
    private Vector3 _strikePosition;
    private float _strikerPositionResetTime = 2f;
    private bool _striked = false;

    /*-----------------------------------------------------------------------
     |  All constants are defined here
     *----------------------------------------------------------------------*/
    private const float X_BOUND = 3.15f;
    private const float Y_BOUND = 5f;
    private const float MAX_STRIKE_FORCE = 50f;
    private const float MIN_STRIKE_FORCE = 10f;

    /*-----------------------------------------------------------------------
     |  Unity predefined methods
     *----------------------------------------------------------------------*/
    private void Start() 
    {
        _strikerRb2D = GetComponent<Rigidbody2D>(); 
        _strikePosition = GetRandomStrikePosition();        
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void FixedUpdate() 
    {
        if(!_gameManager.gameover && !_striked)
        {
            Vector3 displacement = _strikePosition - transform.position;
            Vector3 velocity = displacement.normalized;
            
            if(displacement.magnitude > 0.5)
                transform.Translate(velocity);
            else
                Strike();
        }
    }
    
    /*-----------------------------------------------------------------------
     |  my defined methods
     *----------------------------------------------------------------------*/
    private Vector3 GetRandomStrikePosition()
    {
        float x = Random.Range(-X_BOUND, X_BOUND);
        return new Vector3(x, 4, 0);
    }
    
    private Vector3 GetRandomStrikeDirection()
    {
        float x = Random.Range(-X_BOUND, X_BOUND);
        float y = Random.Range(-Y_BOUND, Y_BOUND);
        float z = 0;
        return (transform.position - new Vector3(x, y, z));
    }

    private float StrikeForce()
    {
        return Random.Range(MIN_STRIKE_FORCE, MAX_STRIKE_FORCE);
    }

    private void ResetPosition()
    {
        _gameManager.ChangeTurn();
        Destroy(gameObject);
    }

    private void Strike() 
    {
        _striked = true;
        Invoke("ResetPosition", _strikerPositionResetTime);
        _strikerRb2D.AddForce(GetRandomStrikeDirection().normalized * StrikeForce(), ForceMode2D.Impulse);
    }
}