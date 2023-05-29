using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    /*-----------------------------------------------------------------------
     |  All private variables 
     *----------------------------------------------------------------------*/
    private Rigidbody2D _rigidbody2D;

    /*-----------------------------------------------------------------------
     |  All public variable 
     *----------------------------------------------------------------------*/
    public float frictionAmount = 0.02f;

    /*-----------------------------------------------------------------------
     |  Unity predefined methods
     *----------------------------------------------------------------------*/
    private void Start() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();    
    }

    private void Update() 
    {
        if(_rigidbody2D.velocity.magnitude >= 0.25 && _rigidbody2D.velocity.magnitude != 0)
            _rigidbody2D.velocity -= _rigidbody2D.velocity.normalized * frictionAmount;  
        else if(_rigidbody2D.velocity.magnitude != 0)
            _rigidbody2D.velocity = Vector3.zero;

    }
}
