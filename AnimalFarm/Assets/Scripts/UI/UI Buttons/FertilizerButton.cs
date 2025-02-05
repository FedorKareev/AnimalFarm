using UnityEngine;

public class FertilizerButton : InventoryButton
{
    [SerializeField]
    private GardenbedScript gardenbedScript;
    [SerializeField]
    private float _multiplaier;
    public void Subtractfrominventory()
    {
        if (inventoryData.Amount > 0 && !gardenbedScript.IsSpawned)
        {
            inventoryData.Amount--;
            gardenbedScript.ChangeMultiplierByFertilizers(_multiplaier);
        }
    }
}
