using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBuilding : Building
{
    [SerializeField] private List<DefenseBuildingSO> defenseBuildingSOList;
    DefenseBuildingSO defenseBuildingSO;

    public override void OnUpgradeComplete()
    {
        defenseBuildingSO = defenseBuildingSOList[CurrentLevel()];
    }
}
