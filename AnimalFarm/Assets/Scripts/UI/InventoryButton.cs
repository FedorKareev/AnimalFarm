using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField]
    private ItemData inventoryData;
    [SerializeField]
    private Text amountCount;
    [SerializeField]
    private Discription discriptionPlane;
    private int count;


    private void Update()
    {
        UpdateAmount();
    }
    public void UpdateAmount()
    {
        amountCount.text = inventoryData.Amount.ToString();
    }
    public void ShowDicription()
    {
        discriptionPlane.ShowDicription(inventoryData.Icon, inventoryData.Discription);
    }
}
