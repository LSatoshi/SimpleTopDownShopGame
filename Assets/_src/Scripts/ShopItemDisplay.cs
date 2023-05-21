using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemDisplay : MonoBehaviour, IItemDisplay
{
    [SerializeField] Item ItemData;
    [SerializeField] TextMeshProUGUI ItemName;
    [SerializeField] TextMeshProUGUI Price;
    [SerializeField] Image Icon;

    public void SetItemData(Item item)
    {
        ItemData = item;
        PopulateShopItemDisplay();
    }

    private void PopulateShopItemDisplay()
    {
        ItemName.text = ItemData.itemName;
        Price.text = "$" + ItemData.buyingPrice.ToString();
        Icon.sprite = ItemData.sprite;
    }

    public void SellItem() 
    {
        if(ItemData)
            FindObjectOfType<ShoppingManager>().SellItemFromPlayer(ItemData);
    }

    public void BuyItem() 
    {
        if(ItemData)
            FindObjectOfType<ShoppingManager>().BuyItemToPlayer(ItemData);
    }
}
