using UnityEngine;

public class ObjectInteract : MonoBehaviour, IInteractuable
{
    [SerializeField] public GameObject _object;
    [SerializeField] private GameObject _canvasObject;

    private PlayerController _playerController;
    private bool _isActive;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        Interactuar();
    }

    private void CogerObjeto()
    {
        if (_isActive)
        {
            _playerController.InteractionObjectPublic();

            if (_object.tag == "PickUpObject")
            {
                ActiveTrueFalse.Activefalse(_canvasObject);
            }
        }
    }

    private void SoltarObjecto()
    {
        if (_isActive)
        {
            _playerController.InteractionObjectPublic();

            if ( _object.tag == "InteractiveObject")
            {
                ActiveTrueFalse.ActiveTrue(_canvasObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ActiveTrueFalse.ActiveTrue(_canvasObject);
            _isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ActiveTrueFalse.Activefalse(_canvasObject);
            _isActive = false;
        }
    }

    public void Interactuar()
    {
        CogerObjeto();
        SoltarObjecto();
    }
}
