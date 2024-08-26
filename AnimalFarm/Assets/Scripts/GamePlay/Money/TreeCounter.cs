using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TreeCounter : MonoBehaviour
{
    [SerializeField]
    private Text _counterText;
    public static int _amount;
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
        _amount += 15;
    }
    private void Start()
    {
        _counterText = GetComponent<Text>();
    }
    private void Update()
    {
        _counterText.text = _amount.ToString();
    }
}
