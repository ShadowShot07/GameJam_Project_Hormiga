using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;

    [SerializeField] private Vector2 _playerDirection;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private Transform _groundController;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Vector3 _boxDimension;

    private Player _player;

    private bool _grounded;

    private InputAction _moveAction;
    private InputAction _interactionAction;

    private bool _lookRight = true;
    private Rigidbody2D _playerRB;

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

        _grounded = Physics2D.OverlapBox(_groundController.position, _boxDimension, 0f, _groundMask);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_grounded) { _playerRB.velocity = new Vector2(_playerSpeed * _playerDirection.x, _playerRB.velocity.y); }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_groundController.position, _boxDimension);
    }
}