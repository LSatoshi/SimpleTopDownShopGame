using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyHUD : MonoBehaviour
{
    [SerializeField] PlayerState state;
    [SerializeField] TextMeshProUGUI MoneyText;
    private int currentMoney = 0;

    void Update()
    {
        if(state.CurrentMoney != currentMoney)
            MoneyText.text = "$" + state.CurrentMoney.ToString();
    }
}
