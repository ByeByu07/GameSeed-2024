using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance { get; private set; }

    [ShowInInspector]
    public int money;
    [SerializeField] private int firstMoney = 20;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameHandler.Instance.OnDayChanged += GameHandler_OnDayChanged;
        money = firstMoney;
        Coins.OnCollideWithPlayer += Coins_OnCollideWithPlayer;
    }

    private void Coins_OnCollideWithPlayer()
    {
        money += 1;
        // visual effect ui scale animation
    }

    private void GameHandler_OnDayChanged(object sender, GameHandler.OnDayChangedEventHandler e)
    {
        var moneyMoney = BuildingManager.Instance.GetBuildingList().OfType<MoneyMakerBuilding>();

        if(moneyMoney != null )
        {
            foreach (MoneyMakerBuilding moneyMaker in moneyMoney)
            {
                //money += moneyMaker.MoneyMakerBuildingSO.earn;
                moneyMaker.InstantiateCoins(moneyMaker.MoneyMakerBuildingSO.earn);
            }
        }
    }

    public bool CanBuyBuilding(int cost)
    {
        if(money - cost >= 0)
        {
            money -= cost;
            Debug.Log(money);
            return true;
        }

        return false;
    }
}
