using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.Properties;

public class TreeCounter : MonoBehaviour
{

    public static ItemData woodData;

    [SerializeField]
    private ItemData ItemData;

    private int _amount;
    private Text _counterText;

    private void OnEnable()
    {
        TreeHealth.OnTreeDestroy += AddWood;
    }
    private void OnDisable()
    {
        TreeHealth.OnTreeDestroy -= AddWood;
    }

    private void AddWood()
    {
        woodData.Amount += 5;
    }
    private void Start()
    {
        _counterText = GetComponent<Text>();
        woodData = ItemData;
    }
    private void Update()
    {
        _counterText.text = woodData.Amount.ToString();
    }

}
