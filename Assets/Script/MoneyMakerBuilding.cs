using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMakerBuilding : Building
{
    public List<MoneyMakerBuildingSO> moneyMakerBuildingSOList;
    public MoneyMakerBuildingSO MoneyMakerBuildingSO { get; private set; }

    public Coins coins;

    private void Awake()
    {
        MoneyMakerBuildingSO = moneyMakerBuildingSOList[CurrentLevel()]; 
    }

    
    public override void OnUpgradeComplete()
    {
        MoneyMakerBuildingSO = moneyMakerBuildingSOList[CurrentLevel()];
    }

    public void InstantiateCoins(int earn)
    {
        for (int i = 0; i< earn; i++)
        {
            float randomPos = Random.Range(-1, 1);
            float height = 3;
            Vector3 newPos = transform.position + new Vector3(randomPos, height, randomPos);
            Instantiate(coins, newPos, Quaternion.identity);
        }
    }
}
