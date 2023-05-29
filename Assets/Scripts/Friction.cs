using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public float frictionAmount = 0.02f;

    private void Start() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();    
    }

    private void Update() 
    {
        if(_rigidbody2D.velocity.magnitude >= 0.1 && _rigidbody2D.velocity.magnitude != 0)
            _rigidbody2D.velocity -= _rigidbody2D.velocity.normalized * frictionAmount;   
    }
}
