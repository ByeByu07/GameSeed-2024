using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeBuildingUI : MonoBehaviour
{
    [SerializeField] private Transform maxScreen;
    [SerializeField] private Building building;
    [SerializeField] private TextMeshProUGUI textCost;
    void Start()
    {
        building.OnSuccessUpgradeLevel += Building_OnSuccessUpgradeLevel;

        textCost.text = building.GetCurrentCost().ToString();
    }

    private void Building_OnSuccessUpgradeLevel(object sender, Building.OnSuccessUpgradeLevelEventHandler e)
    {
        if (building.IsLevelMax())
        {
            maxScreen.gameObject.SetActive(true);
        }
        else
        {
            textCost.text = e.cost.ToString();
        }
    }
}
