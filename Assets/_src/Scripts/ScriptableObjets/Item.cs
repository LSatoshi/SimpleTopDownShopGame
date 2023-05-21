using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Data/Item", order = 0)]
public class Item : ScriptableObject {
    [SerializeField] public int buyingPrice, sellingPrice;
    [SerializeField] public string itemName;
    [SerializeField] public Sprite sprite;
}
