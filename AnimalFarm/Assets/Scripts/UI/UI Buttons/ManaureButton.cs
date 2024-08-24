using UnityEngine;
using UnityEngine.UI;

public class MnaureButton : MonoBehaviour
{
    [SerializeField]
    private Duck—oop _gooseCoop;
    [SerializeField]
    private ItemData _itemData;
    [SerializeField]
    private Text _manureAmount;

    private void Update()
    {
        _manureAmount.text = _gooseCoop.Manure.ToString();
    }

    public void CollectManure()
    {
        _itemData.Amount = _gooseCoop.Manure;
        _gooseCoop.ClearManure();
    }
}
