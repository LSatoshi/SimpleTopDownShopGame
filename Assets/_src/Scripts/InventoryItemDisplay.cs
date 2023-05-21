using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemDisplay : MonoBehaviour, IItemDisplay
{
    [SerializeField] Item ItemData;
    [SerializeField] TextMeshProUGUI ItemName;
    [SerializeField] Image Icon;

    public void SetItemData(Item item)
    {
        ItemData = item;
        PopulateItemDisplay();
    }

    private void PopulateItemDisplay()
    {
        ItemName.text = ItemData.itemName;
        Icon.sprite = ItemData.sprite;
    }

    public void EquipItem() 
    {
        if(ItemData != null)
            FindObjectOfType<InventoryManager>().EquipItem(ItemData);
    }

    public void RemoveItem() 
    {
        if(ItemData)
            FindObjectOfType<InventoryManager>().RemoveEquipedItem();
    }
}
