using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeGardenBed : MonoBehaviour
{
    [SerializeField]
    private Text woodForUpdateText;

    private GardenbedScript gardenBed;
    private float woodsForUpgrade = 15;

    private void Update()
    {
        woodForUpdateText.text = woodsForUpgrade.ToString();
    }

    private void Start()
    {
        gardenBed = GetComponent<GardenbedScript>();
    }

    public void LevelUpGaredenBed()
    {
        if (TreeCounter.woodData.Amount >= woodsForUpgrade)
        {
            gardenBed.ChangeMultiplierByUpgrade(0.15f);
            TreeCounter.woodData.Amount -= (int)woodsForUpgrade;
            woodsForUpgrade *= 1.1f;
            woodsForUpgrade = Mathf.Round(woodsForUpgrade);
        }
    }
}
