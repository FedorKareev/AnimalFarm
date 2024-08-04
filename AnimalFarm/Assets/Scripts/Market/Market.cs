using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Market : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> _itemDatas = new List<ItemData>();
    [SerializeField]
    private Text _moneyCounter;

    [SerializeField]
    private Money _money;

    private void OnTriggerEnter(Collider other)
    {
        Saller saller = other.GetComponent<Saller>();
        if (saller != null) 
        {
            Sall();
        }
    }
   private void Sall()
    {
        foreach (ItemData item in _itemDatas)
        {
            if (item.Amount > 0) 
            {
                _money._money += item.PriceForSell * item.Amount;
                item.Amount = 0;
            }
            else
            {
                Debug.Log("ќвощей нет на продажу");
            }
        }
    }
}
