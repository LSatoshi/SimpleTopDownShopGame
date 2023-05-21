using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] PlayerState PlayerState;
    [SerializeField] GameObject InventoryMenu;
    [SerializeField] Transform PlayerInventory;
    [SerializeField] Transform PlayerEquipedItem;
    [SerializeField] GameObject InventoryItemPrefab;
    [SerializeField] GameObject EquipedItemPrefab;

    public void OpenInventory()
    {
        PlayerState.SetPlayerCanMove(false);
        InventoryMenu.SetActive(true);

        ReloadInventory();
    }

    public void CloseInventory()
    {
        PlayerState.SetPlayerCanMove(true);
        InventoryMenu.SetActive(false);
    }

    public void EquipItem(Item item)
    {
        PlayerState.EquipItem(item);
        ReloadInventory();
    }

    public void RemoveEquipedItem()
    {
        PlayerState.RemoveEquipedItem();
        ReloadInventory();
    }

    private void ReloadInventory()
    {
        for (var i = PlayerInventory.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(PlayerInventory.GetChild(i).gameObject);
        }
        if(PlayerEquipedItem.childCount > 0)
            Object.Destroy(PlayerEquipedItem.GetChild(0).gameObject);

        foreach(Item item in PlayerState.GetInventory()) 
        {
            GameObject newItem = Instantiate(InventoryItemPrefab, PlayerInventory);
            newItem.GetComponent<IItemDisplay>().SetItemData(item);
        }
        if(PlayerState.GetEquipedItem() != null)
        {
            GameObject equipedItem = Instantiate(EquipedItemPrefab, PlayerEquipedItem);
            equipedItem.GetComponent<IItemDisplay>().SetItemData(PlayerState.GetEquipedItem());
        }
    }

    public void ResetMoney()
    {
        PlayerState.ResetMoney();
    }
}
