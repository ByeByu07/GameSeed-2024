using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilding : Building
{
    List<TowerBuildingSO> towerBuildingSOList;
    TowerBuildingSO towerBuildingSO;

    private void Awake()
    {
        towerBuildingSOList = new List<TowerBuildingSO>();
    }
    public override void OnUpgradeComplete()
    {
        towerBuildingSO = towerBuildingSOList[CurrentLevel()];
    }
}
