using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonsBase : MonoBehaviour
{
    [SerializeField]
    private ItemData inventoryData;
    [SerializeField]
    private Discription discriptionPlane;
    [SerializeField]
    private Text amountCount;
    private void Update()
    {
        UpdateAmount();
    }
    public virtual void UpdateAmount()
    {
        amountCount.text = inventoryData.Amount.ToString();
    }
    public virtual void ShowDicription()
    {
        discriptionPlane.ShowDicription(inventoryData.Icon, inventoryData.Discription);
    }
}
