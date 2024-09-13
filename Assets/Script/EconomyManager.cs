using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance { get; private set; }
    public event Action OnBuyBuilding;

    [ShowInInspector]
    public int money;
    [SerializeField] private int firstMoney = 20;

    private void Awake()
    {
        Instance = this;
        money = firstMoney;
    }

    private void Start()
    {
        GameHandler.Instance.OnDayChanged += GameHandler_OnDayChanged;
        Coins.OnCollideWithPlayer += Coins_OnCollideWithPlayer;
    }

    private void Coins_OnCollideWithPlayer()
    {
        money += 1;
        // visual effect ui scale animation
    }

    private void GameHandler_OnDayChanged(object sender, GameHandler.OnDayChangedEventHandler e)
    {
        var moneyMoney = BuildingManager.Instance.GetBuildingActiveList().OfType<MoneyMakerBuilding>();

        Debug.Log(moneyMoney);

        if (moneyMoney.Any())
        {
            foreach (MoneyMakerBuilding moneyMaker in moneyMoney)
            {
                Debug.Log("this");
                if(moneyMaker.gameObject.activeInHierarchy)
                {
                    Debug.Log("thus");
                    moneyMaker.InstantiateCoins(moneyMaker.MoneyMakerBuildingSO.earn);
                }
            }
        }
    }

    public bool CanBuyBuilding(int cost)
    {
        if(money - cost >= 0)
        {
            money -= cost;
            OnBuyBuilding?.Invoke();
            Debug.Log(money);
            return true;
        }

        return false;
    }
}
