using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject invetoryPanel;
    private bool IsInventoryOpen = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!IsInventoryOpen)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }
    }
    private void OpenMenu()
    {
        invetoryPanel.SetActive(true);
        IsInventoryOpen = true;
    }
    private void CloseMenu()
    {
        invetoryPanel.SetActive(false);
        IsInventoryOpen = false;
    }
}
