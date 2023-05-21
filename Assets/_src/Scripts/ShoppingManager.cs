using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingManager : MonoBehaviour
{
    [SerializeField] PlayerState PlayerState;
    [SerializeField] GameObject ShopMenu;
    [SerializeField] Transform ShopItemList;
    [SerializeField] GameObject ShopItemPrefab;
    [SerializeField] Transform PlayerInventory;
    [SerializeField] GameObject InventoryItemPrefab;

    public void OpenShop(Item[] ShopInventory)
    {
        PlayerState.SetPlayerCanMove(false);
        ShopMenu.SetActive(true);

        ClearShopItems();
        ReloadPlayerInventory();

        foreach(Item item in ShopInventory) 
        {
            GameObject newItem = Instantiate(ShopItemPrefab, ShopItemList);
            newItem.GetComponent<ShopItemDisplay>().SetItemData(item);
        }
    }

    public void CloseShop()
    {
        PlayerState.SetPlayerCanMove(true);
        ShopMenu.SetActive(false);
    }

    private void ClearShopItems()
    {
        for (var i = ShopItemList.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(ShopItemList.GetChild(i).gameObject);
        }
    }

    private void ReloadPlayerInventory()
    {
        for (var i = PlayerInventory.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(PlayerInventory.GetChild(i).gameObject);
        }

        foreach(Item item in PlayerState.GetInventory()) 
        {
            GameObject newItem = Instantiate(InventoryItemPrefab, PlayerInventory);
            newItem.GetComponent<IItemDisplay>().SetItemData(item);
        }
    }

    public void BuyItemToPlayer(Item item) 
    {
        if(PlayerState.RemoveMoney(item.buyingPrice))
        {         
            PlayerState.AddItemToInventory(item);
            ReloadPlayerInventory();
        }
    }

    public void SellItemFromPlayer(Item item) 
    {
        PlayerState.AddMoney(item.sellingPrice);
        PlayerState.RemoveItemFromInventory(item);
        ReloadPlayerInventory();
    }
}
