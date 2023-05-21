using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : AInteractable
{
    [SerializeField] private GameObject Icon;
    [SerializeField] Item[] ShopInventory;
    private ShoppingManager shoppingManager;
    override public GameObject GetInteractableIcon() => Icon;

    void Start() {
        shoppingManager = FindObjectOfType<ShoppingManager>();
    }

    override public void Interact()
    {
        shoppingManager.OpenShop(ShopInventory);
    }
}