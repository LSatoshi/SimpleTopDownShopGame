using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AInteractable : MonoBehaviour
{
    private bool _playerIsClose;
    public bool PlayerIsClose => _playerIsClose;

    public abstract void Interact();
    public abstract GameObject GetInteractableIcon();

    private void enableInteractableIcon()
    {
        GetInteractableIcon().SetActive(true);
    }

    private void disableInteractableIcon()
    {
        GetInteractableIcon().SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsClose)
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enableInteractableIcon();
            _playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            disableInteractableIcon();
            _playerIsClose = false;
        }
    }
}
