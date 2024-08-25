using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField]
    protected ItemData inventoryData;
    [SerializeField]
    protected Text amountCount;
    [SerializeField]
    protected Discription discriptionPlane;


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
