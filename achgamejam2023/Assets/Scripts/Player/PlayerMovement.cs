using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody2D;
    
    private Vector2 _playerDirection;

    [SerializeField] float movementSpeed = 1;

    [SerializeField] private Animator playerAnimator;

    // Update is called once per frame
    private void Update()
    {
        _playerDirection.x = Input.GetAxisRaw("Horizontal");
        _playerDirection.y = Input.GetAxisRaw("Vertical");
        
        playerAnimator.SetFloat("Horizontal", _playerDirection.x);
        playerAnimator.SetFloat("Vertical", _playerDirection.y);
        playerAnimator.SetFloat("Speed", _playerDirection.sqrMagnitude);
        
        
    }

    void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + 
                                  _playerDirection * 
                                  (movementSpeed * GameManager.Instance.GetSpeedMultiplier()) * Time.fixedDeltaTime);
    }
}

// References
// https://youtu.be/whzomFgjT50
