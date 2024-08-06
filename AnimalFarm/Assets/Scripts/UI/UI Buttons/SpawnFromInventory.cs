using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFromInventory : InventoryButton
{

    [SerializeField]
    private SpawnObjectsBase spawnObjectScript;
    [SerializeField]
    private int plantIndex;

    public void Subtractfrominventory()
    {

        if (inventoryData.Amount > 0 && !spawnObjectScript.IsSpawned)
        {
            inventoryData.Amount--;
            spawnObjectScript.SelectObject(plantIndex);
        }
    }
}
