using UnityEngine;


[CreateAssetMenu(fileName = "New Building item", menuName = "Inventory System/Items/NewInventoryData")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private Sprite icon;
    [SerializeField, TextArea(15, 30)]
    private string discription;
    [SerializeField]
    private int amount;
    [SerializeField]
    private int priceForBuy;
    [SerializeField]
    private int priceForSell;

    public string Discription
    {
        get
        {
            return discription;
        }
    }
    public int Amount
    {
        get
        {
            return amount;
        }
        set
        {
            amount = value;
        }
    }
    public int PriceForBuy
    {
        get 
        {
            return priceForBuy;
        }
    }
    public int PriceForSell
    {
        get
        {
            return priceForSell;
        }
    }
    public Sprite Icon
    {
        get
        {
            return icon;
        }
    }
    private void OnDisable()
    {
        amount = 0;
    }
}
