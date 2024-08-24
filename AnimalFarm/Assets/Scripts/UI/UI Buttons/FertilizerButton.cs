using UnityEngine;

public class FertilizerButton : InventoryButton
{
    [SerializeField]
    private GardenbedScript gardenbedScript;
    [SerializeField]
    private float _multiplaier;
    public void Subtractfrominventory()
    {
        if (inventoryData.Amount > 0 && gardenbedScript.TimeMultiplair < _multiplaier && !gardenbedScript.IsSpawned)
        {
            inventoryData.Amount--;
            gardenbedScript.ChangeMultiplier(_multiplaier);
        }
    }
}
