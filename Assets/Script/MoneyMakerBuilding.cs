using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMakerBuilding : Building
{
    public List<MoneyMakerBuildingSO> moneyMakerBuildingSOList;
    public MoneyMakerBuildingSO MoneyMakerBuildingSO { get; private set; }

    private void Awake()
    {
        MoneyMakerBuildingSO = moneyMakerBuildingSOList[CurrentLevel()]; 
    }
    
    public override void OnUpgradeComplete()
    {
        MoneyMakerBuildingSO = moneyMakerBuildingSOList[CurrentLevel()];
    }
}
