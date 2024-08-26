using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LaptopButton : InventoryButton
{
    [SerializeField]
    private Text _costCount;
    [SerializeField]
    private Money _moneyScript;
    [SerializeField]
    private RandomSpawn _randomSpawn;
    [SerializeField]
    private Goods goods;

    public override void UpdateAmount()
    {
        _costCount.text = inventoryData.PriceForBuy.ToString();
        base.UpdateAmount();
    }

    public void BuyItem()
    {
        if (_moneyScript._amount >= inventoryData.PriceForBuy)
        {
            _moneyScript._amount -= inventoryData.PriceForBuy;
            _randomSpawn.SpawnInRadius(goods);
        }
        else
        {
            Debug.Log("Не достаточно средств");
        }
    }
}
