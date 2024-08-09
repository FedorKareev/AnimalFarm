using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchGameMode : MonoBehaviour
{
    [SerializeField]
    private GameObject buildingPanel, virtualCam1;
    [SerializeField]
    private PlayerMovement playerMovementScript;
    private bool IsBuildingOn;

    private void Start()
    {
        IsBuildingOn = false;
    }

    public void SwitchMechanics()
    {
        if(!IsBuildingOn)
        {
            OnBuildingMode();
        }
        else
        {
            OffBuildingMode();
        }
    }

    private void OnBuildingMode()
    {
        buildingPanel.SetActive(true);
        virtualCam1.SetActive(false);
        PlayerMovement.IsMoveble = false;
        IsBuildingOn = true;
    }
    private void OffBuildingMode()
    {
        buildingPanel.SetActive(false);
        virtualCam1.SetActive(true);
        PlayerMovement.IsMoveble = true;
        IsBuildingOn = false;
    }
}
