using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenUI : MonoBehaviour
{
    [SerializeField] private Transform containerCoinsUI;
    [SerializeField] private TextMeshProUGUI coinsAmountText;
    Vector3 originalLocalScale = Vector3.one;
    void Start()
    {
        Coins.OnCollideWithPlayer += Coins_OnCollideWithPlayer;
        EconomyManager.Instance.OnBuyBuilding += EconomyManager_OnBuyBuilding;
        UpdateVisual();
    }

    private void EconomyManager_OnBuyBuilding()
    {
        UpdateVisual();
    }

    private void Coins_OnCollideWithPlayer()
    {
        containerCoinsUI.DOComplete();
        containerCoinsUI.DOShakeScale(0.3f, 0.5f, 5, 180, true).OnKill(() => { if (transform) { transform.localScale = originalLocalScale; } });
        coinsAmountText.text = EconomyManager.Instance.money.ToString();
    }

    public void UpdateVisual()
    {
        coinsAmountText.text = EconomyManager.Instance.money.ToString();
    }
}
