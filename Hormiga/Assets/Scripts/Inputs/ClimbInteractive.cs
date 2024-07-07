using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbInteractive : MonoBehaviour, IInteractuable
{
    [SerializeField] private GameObject _canvasObject;
    [SerializeField] public Transform _arriba;

    private PlayerController _playerController;
    [SerializeField ]private bool _isActive;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    private void UsarEscalera()
    {
        if (_isActive)
        {
            //_playerController.InteractionClimbPublic();
        }
        else
        {
            //_playerController.InteractionClimbStopPublic();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
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

    public void Interactuar(PlayerController player)
    {
        UsarEscalera();
    }
}
