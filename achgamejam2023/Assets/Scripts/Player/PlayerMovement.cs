using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody2D;
    
    private Vector2 _playerDirection;

    [SerializeField] float movementSpeed = 1;

    private GameManager _GM;
    // Start is called before the first frame update
    void Start()
    {
        _GM = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    private void Update()
    {
        _playerDirection.x = Input.GetAxisRaw("Horizontal");
        _playerDirection.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + 
                                  _playerDirection * (movementSpeed * _GM.GetSpeedMultiplier()) * Time.fixedDeltaTime);
    }
}
