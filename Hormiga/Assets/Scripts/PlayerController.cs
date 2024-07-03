using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] private Vector2 _playerDirection;
    [SerializeField] private float _playerSpeed;

    private Rigidbody2D _playerRB;
    private InputAction _moveAction;
    private InputAction _interactionAction;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerRB = GetComponent<Rigidbody2D>();
        _moveAction = _playerInput.actions["Move"];
        _interactionAction = _playerInput.actions["Action"];
    }

    private void Update()
    {
        _playerDirection = _moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _playerRB.velocity = new Vector2(_playerSpeed * _playerDirection.x, _playerRB.velocity.y);
    }
}
