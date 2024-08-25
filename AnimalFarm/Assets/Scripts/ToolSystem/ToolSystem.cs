using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToolSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject axeIcon;
    [SerializeField]
    private GameObject axe;
    private bool isAxeUse;

    private void Start()
    {
        isAxeUse = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!isAxeUse)
            {
                GetAxe();
            }
            else
            {
                PutAwayAxe();
            }
        }
    }

    void GetAxe()
    {
        axeIcon.SetActive(true);
        isAxeUse = true;
        axe.SetActive(true);
    }
    void PutAwayAxe()
    {
        axeIcon.SetActive(false);
        isAxeUse = false;
        axe.SetActive(false);
    }

    public bool IsAxeUse()
    {
        return isAxeUse;
    }
}
