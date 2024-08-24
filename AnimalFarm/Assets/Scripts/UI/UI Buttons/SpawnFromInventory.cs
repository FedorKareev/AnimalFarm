using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFromInventory : InventoryButton
{

    [SerializeField]
    private SpawnObjectsBase spawnObjectScript;
    [SerializeField]
    private int objectIndex;

    public void Subtractfrominventory()
    {

        if (inventoryData.Amount > 0 && !spawnObjectScript.IsSpawned)
        {
            inventoryData.Amount--;
            spawnObjectScript.SelectObject(objectIndex);
        }
    }
}
