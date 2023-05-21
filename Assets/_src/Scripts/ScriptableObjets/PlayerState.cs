using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerState", menuName = "Data/PlayerState", order = 0)]
public class PlayerState : ScriptableObject {
    [SerializeField] int currentMoney;
    [SerializeField] int MAX_SIZE = 10;
	[SerializeField] List<Item> inventory;
    [SerializeField] Item equipedItem;
    public int CurrentMoney => currentMoney;
    private bool _canMove = true;

    public List<Item> GetInventory() => inventory;
    public Item GetEquipedItem() => equipedItem;

    public void SetPlayerCanMove(bool canMove) => _canMove = canMove;
    public bool GetPlayerCanMove() => _canMove;

    public void EquipItem(Item item)
    {
        if(equipedItem != null)
            AddItemToInventory(equipedItem);
        RemoveItemFromInventory(item);
        equipedItem = item;
    }

    public void RemoveEquipedItem()
    {
        AddItemToInventory(equipedItem);
        equipedItem = null;
    }

    public void AddItemToInventory(Item item)
    {
        if(inventory.Count < MAX_SIZE)
            inventory.Add(item);
    }

    public bool RemoveItemFromInventory(Item item)
    {
        return inventory.Remove(item);
    }

    public bool RemoveMoney(int quantity)
    {
        if(quantity > currentMoney)
        {
            return false;
        }
        else
        {
            currentMoney -= quantity;
            return true;
        }
    }

    public void AddMoney(int quantity)
    {
        currentMoney += quantity;
    }

    public void ResetMoney()
    {
        currentMoney = 1500;
    }
}