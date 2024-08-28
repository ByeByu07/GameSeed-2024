using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance { get; private set; }

    [ShowInInspector]
    public int Money { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameHandler.Instance.OnDayChanged += GameHandler_OnDayChanged;
    }

    private void GameHandler_OnDayChanged(object sender, GameHandler.OnDayChangedEventHandler e)
    {
        var moneyMoney = BuildingManager.Instance.GetBuildingList().OfType<MoneyMakerBuilding>();

        foreach (MoneyMakerBuilding moneyMaker in moneyMoney)
        {
            Money += moneyMaker.MoneyMakerBuildingSO.earn;
        }
    }
}
