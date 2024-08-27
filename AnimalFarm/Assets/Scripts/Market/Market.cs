using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using static UnityEditor.Progress;

public class Market : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> _itemDatas = new List<ItemData>();
    [SerializeField]
    private GameObject _marketUI;
    [SerializeField]
    private Money _money;

    private void OnTriggerEnter(Collider other)
    {
        Saller saller = other.GetComponent<Saller>();
        if (saller != null)
        {
            _marketUI.SetActive(true);
        }
    }

    public void Sall(ItemData itemData)
    {
        if (itemData.Amount > 0)
        {
            _money._amount += itemData.PriceForSell;
            itemData.Amount--;
        }
    }
}
