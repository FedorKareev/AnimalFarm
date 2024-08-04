using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LaptopButton : MonoBehaviour
{
    [SerializeField]
    private ItemData inventoryData;
    [SerializeField]
    private Text amountCount;
    [SerializeField]
    private Text _costCount;
    [SerializeField]
    private Money _moneyScript;
    [SerializeField]
    private Discription discriptionPlane;
    [SerializeField]
    private RandomSpawn _randomSpawn;
    [SerializeField]
    private Goods goods;
    private void Update()
    {
        UpdateAmount();
    }
    public void UpdateAmount()
    {
        amountCount.text = inventoryData.Amount.ToString();
        _costCount.text = inventoryData.PriceForBuy.ToString();
    }
    public void ShowDicription()
    {
        discriptionPlane.ShowDicription(inventoryData.Icon, inventoryData.Discription);
    }

    public void BuyItem()
    {
        if (_moneyScript._money >= inventoryData.PriceForBuy)
        {
            _moneyScript._money -= inventoryData.PriceForBuy;
            _randomSpawn.SpawnInRadius(goods);
        }
        else
        {
            Debug.Log("Не достаточно средств");
        }
    }
}
