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

    public void Interactuar(PlayerController player)
    {
        if (_isActive)
        {
            transform.SetParent(player._playerClamp);
            transform.position = player._playerClamp.position;
            GetComponent<Rigidbody2D>().isKinematic = true;
            player._playerAnimator.SetBool("TakeObject", true);
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
}
