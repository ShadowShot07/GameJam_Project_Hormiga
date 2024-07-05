using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Velocidad del jugador")]  
    [SerializeField] private float _playerSpeed;

    [Header("Controlador de Suelo")]
    [SerializeField] private Transform _groundController;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Vector3 _boxDimension;

    private bool _lookRight = true;
    private Rigidbody2D _playerRB;
    private Vector2 _playerDirection;
    private bool _grounded;

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _interactionAction;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerRB = GetComponent<Rigidbody2D>();
        _moveAction = _playerInput.actions["Move"];
        _interactionAction = _playerInput.actions["Action"];
    }

    private void Start()
    {
        _interactionAction.started += Interaction;
    }

    private void Interaction(InputAction.CallbackContext context)
    {
        Debug.Log("estoy interactuando");
    }

    private void Update()
    {
        _playerDirection = _moveAction.ReadValue<Vector2>();
        _grounded = Physics2D.OverlapBox(_groundController.position, _boxDimension, 0f, _groundMask);

        RotatePlayer(_playerDirection.x);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_grounded) { _playerRB.velocity = new Vector2(_playerDirection.x * _playerSpeed, _playerRB.velocity.y); }
    }

    private void RotatePlayer(float x)
    {
        if (x > 0 && !_lookRight)
        {
            Rotate();
        } else if (x < 0 && _lookRight)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        _lookRight = !_lookRight;
        Vector2 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_groundController.position, _boxDimension);
    }
}