using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDay : MonoBehaviour, IInteractuable
{
    [SerializeField] public GameObject _objectBed;
    [SerializeField] private GameObject _canvasObject;

    private PlayerController _playerController;
    [SerializeField] private bool _isActive;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    private void PasarDia()
    {
        if (_isActive)
        {
           // _playerController.InteractionFinishDayPublic();
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

    public void Interactuar(PlayerController player)
    {
        PasarDia();
    }
}
