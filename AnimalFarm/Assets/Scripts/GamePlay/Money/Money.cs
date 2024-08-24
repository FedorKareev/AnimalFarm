using UnityEngine.UI;
using UnityEngine;

public class Money : MonoBehaviour
{
    private Text _moneyCounter;
    
    public int _money { get; set; }
    private void Start()
    {
        _moneyCounter = GetComponent<Text>();
        //_money += 10000;
    }

    private void Update()
    {
        _moneyCounter.text = _money.ToString();
    }
}
