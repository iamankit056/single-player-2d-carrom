using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStriker : MonoBehaviour
{
    [SerializeField] private Slider _strikerController;

    private Rigidbody2D _strikerRb2D;
    private float _strikeForce = 100f;
    private Vector3 _strikeDirection;

    private void Start() 
    {
        _strikerRb2D = GetComponent<Rigidbody2D>();
        _strikerController.onValueChanged.AddListener(delegate { MoveOnXAxis(); });  
    }

    private void MoveOnXAxis()
    {
        transform.position = new Vector3(
            _strikerController.value,
            transform.position.y,
            transform.position.z
        );
    }

    private void OnMouseDrag() 
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _strikeDirection = transform.position - mousePosition;
    }

    private void OnMouseUp() 
    {
        _strikerRb2D.AddForce(_strikeDirection.normalized * _strikeForce, ForceMode2D.Impulse);
    }
}
