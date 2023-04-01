using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float increment = 3;
    [SerializeField] private float movementSpeed = 5f;
    
    private Vector2 _movement;

    private bool _isMoving = false;

    private GameManager _gm;
    // Start is called before the first frame update
    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveIntoNewDirection());
    }

    void FixedUpdate()
    {
        if (!_isMoving)
        {
            StartCoroutine(MoveIntoNewDirection());
        }
    }

    IEnumerator MoveIntoNewDirection()
    {
        _isMoving = true;
        _movement.x = Random.Range(-increment, increment);
        _movement.y = Random.Range(-increment, increment);
        Debug.Log("New direction: " + _movement);
        /*
        _rigidbody2D.MovePosition(_rigidbody2D.position + _movement * 
            (GameManager.Instance.GetSpeedMultiplier() * movementSpeed * Time.deltaTime));
        */
        _rigidbody2D.velocity = _movement * (movementSpeed * Time.fixedDeltaTime);
        yield return new WaitForSeconds((5 / _gm.GetSpeedMultiplier()));
        _isMoving = false;

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _rigidbody2D.velocity = new Vector2(-_movement.x, -_movement.y) * (movementSpeed * Time.fixedDeltaTime);
    }
}
