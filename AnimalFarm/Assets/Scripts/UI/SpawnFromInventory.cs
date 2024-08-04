using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFromInventory : MonoBehaviour
{
    [SerializeField]
    private ItemData inventoryDataTest;
    [SerializeField]
    private SpawnObjectsBase spawnObjectScript;
    [SerializeField]
    private Text amountCount;
    [SerializeField]
    private int plantIndex;
    private void Update()
    {
        UpdateAmount();
    }
    public void UpdateAmount()
    {
        amountCount.text = inventoryDataTest.Amount.ToString();
    }

    public void Subtractfrominventory()
    {
        
        if (inventoryDataTest.Amount > 0 && !spawnObjectScript.IsSpawned)
        {
            inventoryDataTest.Amount--;
            spawnObjectScript.SelectObject(plantIndex);
        }
    }
}
