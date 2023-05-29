using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStrikerPosition : MonoBehaviour
{
    [SerializeField] private Vector3 _strikerStartPosition;
    [SerializeField] private GameManager _gameManager;

    private Rigidbody2D _strikerRb2D;

    private void Start() 
    {
        _strikerRb2D = GetComponent<Rigidbody2D>();    
    }
    
    void Update()
    {
        if(_strikerRb2D.velocity.magnitude <= 0.2 && _strikerRb2D.velocity.magnitude != 0)
        {
            transform.position = _strikerStartPosition;
            // _gameManager.ChangeTurn();
        }
    }
}
