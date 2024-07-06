using System;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Objetos Jugador")]
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _playerClamp;

    [Header("Velocidad del jugador")]  
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _playerSpeedClimb;

    [Header("Controlador de Suelo")]
    [SerializeField] private Transform _groundController;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Vector3 _boxDimension;

    // Opciones Player para moverse
    private Animator _playerAnimator;
    private bool _lookRight = true;
    private Rigidbody2D _playerRB;
    private Vector2 _playerDirection;
    private bool _grounded;

    // Inputs del sistema
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _interactionAction;

    // Cosas con las que Interactua el Player
    private ObjectInteract _objectInteract;
    private GameObject _objectInteractable;

    private ClimbInteractive _climbInteractive;
    private Transform _climbInteractable;

    private FinishDay _finishDay;
    private GameObject _finish;

    // Comprobar con que colisiona
    [SerializeField] private bool _isClimb;
    [SerializeField] private bool _isDropObject;
    [SerializeField] private bool _isFinishDay;

    private void Awake()
    {
        _objectInteract = FindObjectOfType<ObjectInteract>();
        _objectInteractable = _objectInteract._object;

        _climbInteractive = FindObjectOfType<ClimbInteractive>();
        _climbInteractable = _climbInteractive._arriba;

        _finishDay = FindObjectOfType<FinishDay>();
        _finish = _finishDay._object;

        _playerInput = GetComponent<PlayerInput>();
        _playerRB = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _moveAction = _playerInput.actions["Move"];
        _interactionAction = _playerInput.actions["Action"];
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

    public void InteractionObjectPublic()
    {
        if (!_isDropObject)
        {
            _interactionAction.started += InteractionTakeObject;
            _interactionAction.started -= InteractionDropObject;
            _interactionAction.started -= InteractionClimb;
            _interactionAction.started -= InteractionStopClimb;
        }
        else if (_isDropObject)
        {
            _interactionAction.started += InteractionDropObject;
            _interactionAction.started -= InteractionTakeObject;
            _interactionAction.started -= InteractionClimb;
            _interactionAction.started -= InteractionStopClimb;
        }
    }

    public void InteractionClimbPublic()
    {
        if (_isClimb)
        {
            _interactionAction.started += InteractionClimb;
            _interactionAction.started -= InteractionDropObject;
            _interactionAction.started -= InteractionTakeObject;
            _interactionAction.started -= InteractionStopClimb;
        }
        else if (!_isClimb)
        {
            _interactionAction.started -= InteractionClimb;
        }
    }

    public void InteractionFinishDayPublic()
    {
        if (_isFinishDay)
        {
            _interactionAction.started += InteractionFinishDay;
            _interactionAction.started -= InteractionStopClimb;
            _interactionAction.started -= InteractionClimb;
            _interactionAction.started -= InteractionDropObject;
            _interactionAction.started -= InteractionTakeObject;
        }
        else if (!_isFinishDay)
        {
            _interactionAction.started -= InteractionFinishDay;
        }
    }

    private void InteractionFinishDay(InputAction.CallbackContext context)
    {
        ScenesManager.instance.LoadNextScene();
    }

    private void InteractionClimb(InputAction.CallbackContext context)
    {
        //_player.transform.position = Vector2.MoveTowards(_player.transform.position, _climbInteractable.position, _playerSpeed * Time.deltaTime);
        
        //_playerRB.velocity = (_climbInteractable.transform.position - transform.position).normalized * _playerSpeedClimb;
        //_playerRB.gravityScale = 0;
        //_playerAnimator.SetBool("Climb", true);
    }

    private void InteractionStopClimb(InputAction.CallbackContext context)
    {
        _player.transform.position = _climbInteractable.position;
        _playerAnimator.SetBool("Climb", false);
    }

    private void InteractionTakeObject(InputAction.CallbackContext context)
    {
        _objectInteractable.transform.SetParent(_playerClamp);
        _objectInteractable.transform.position = _playerClamp.position;
        _objectInteractable.GetComponent<Rigidbody2D>().isKinematic = true;
        _objectInteractable.gameObject.tag = "PickUpObject";
        _playerAnimator.SetBool("TakeObject", true);
    }

    private void InteractionDropObject(InputAction.CallbackContext context)
    {
        _objectInteractable.transform.SetParent(null);
        _objectInteractable.GetComponent<Rigidbody2D>().isKinematic = false;
        _objectInteractable.gameObject.tag = "InteractiveObject";
        _playerAnimator.SetBool("TakeObject", false);
    }

    private void Move()
    {
        if (_grounded) 
        {
            /*if (transform.position == _climbInteractable.transform.position)
            {*/
                _playerRB.velocity = new Vector2(_playerDirection.x * _playerSpeed, _playerRB.velocity.y);
                _playerAnimator.SetFloat("Horizontal", MathF.Abs(_playerDirection.x));
                _playerRB.gravityScale = 1;
                _playerAnimator.SetBool("Climb", false);
            //}
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Climb")
        {
            _isClimb = true;
        }

        if (collision.tag == "InteractiveObject")
        {
            _isDropObject = false;
        }

        if (collision.tag == "FinishDay")
        {
            _isFinishDay = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PickUpObject")
        {
            _isDropObject = true;
        }

        if (collision.tag == "InteractiveObject")
        {
            _isDropObject = false;
        }

        if (collision.tag == "FinishDay")
        {
            _isFinishDay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Climb")
        {
            _isClimb = false;
        }

        if (collision.tag == "InteractiveObject")
        {
            _isDropObject = false;
        }

        if (collision.tag == "FinishDay")
        {
            _isFinishDay = false;
        }
    }
}