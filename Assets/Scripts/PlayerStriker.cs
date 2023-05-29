using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStriker : MonoBehaviour
{
    /*-----------------------------------------------------------------------
     |  All serialize field private variavles
     *----------------------------------------------------------------------*/
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Slider _strikerController;
    [SerializeField] private Vector3 _strikerStartPosition = new Vector3(0, -4, 0);

    /*-----------------------------------------------------------------------
     |  All private variables 
     *----------------------------------------------------------------------*/
    private Rigidbody2D _strikerRb2D;
    private float _strikeForce = 100f;
    private Vector3 _strikeDirection;
    private bool _isStrike = false;
    private float _strikerPositionResetTime = 5f;

    /*-----------------------------------------------------------------------
     |  Unity predefined methods
     *----------------------------------------------------------------------*/
    private void Start() 
    {
        _strikerRb2D = GetComponent<Rigidbody2D>();
        _strikerController.onValueChanged.AddListener(delegate { MoveOnXAxis(); });  
    }

    private void OnMouseDrag() 
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _strikeDirection = transform.position - mousePosition;
    }

    private void OnMouseUp() 
    {
        if(!_isStrike && !_gameManager.gameover)
        {
            _isStrike = true;
            Invoke("ResetPosition", _strikerPositionResetTime);
            _strikerRb2D.AddForce(_strikeDirection.normalized * _strikeForce, ForceMode2D.Impulse);
        }
    }
    
    /*-----------------------------------------------------------------------
     |  my defined methods
     *----------------------------------------------------------------------*/
    private void MoveOnXAxis()
    {
        transform.position = new Vector3(
            _strikerController.value,
            transform.position.y,
            transform.position.z
        );
    }

    private void ResetPosition()
    {
        _isStrike = false;
        _strikerRb2D.velocity = Vector3.zero;
        transform.position = _strikerStartPosition;
    }

    
}
