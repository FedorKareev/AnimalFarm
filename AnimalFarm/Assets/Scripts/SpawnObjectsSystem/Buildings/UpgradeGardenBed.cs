using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeGardenBed : MonoBehaviour
{
    [SerializeField]
    private Text woodForUpdateText;

    private GardenbedScript gardenBed;
    private float woodsForUpgrade = 30;

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
        if (TreeCounter._amount >= woodsForUpgrade)
        {
            gardenBed.ChangeMultiplierByUpgrade(0.15f);
            TreeCounter._amount -= (int)woodsForUpgrade;
            woodsForUpgrade *= 1.3f;
            Mathf.Round(woodsForUpgrade);
        }
    }
}
