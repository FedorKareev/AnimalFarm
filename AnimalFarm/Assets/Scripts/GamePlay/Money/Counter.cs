using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField]
    private Text _counterText;
    public int _amount { get; set; }
    private void Start()
    {
        _counterText = GetComponent<Text>();
    }
    private void Update()
    {
        _counterText.text = _amount.ToString();
    }
}
