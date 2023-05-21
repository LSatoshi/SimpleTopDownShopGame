using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour // change name to player controller and add raycast
{
    [SerializeField] PlayerState PlayerState;
    [SerializeField] SpriteRenderer Hat;
    [SerializeField] private float Speed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    private Vector2 _movement;

    void Start() {
        PlayerState.SetPlayerCanMove(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            FindObjectOfType<InventoryManager>().OpenInventory();
        }
        ChangeHat();
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Horizontal", _movement.x);
        anim.SetFloat("Vertical", _movement.y);
        anim.SetFloat("Speed", _movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        if(PlayerState.GetPlayerCanMove())
            rb.MovePosition(rb.position + _movement.normalized * Speed * Time.fixedDeltaTime); 
    }

    void ChangeHat()
    {
        if(PlayerState.GetEquipedItem() != null)
            Hat.sprite = PlayerState.GetEquipedItem().sprite;
        else
            Hat.sprite = null;
    }
}