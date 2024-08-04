using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    [SerializeField]
    private GameObject LaptopUI;
    private void OnMouseDown()
    {
        LaptopUI.SetActive(true);
    }
}
