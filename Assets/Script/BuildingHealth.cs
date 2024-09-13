using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : Health
{
    public event Action OnBuildingHealthUnderZero;
    [SerializeField] private ContainerBase cb;
    Building building;

    protected new void Start()
    {
        base.Start();
        building = GetComponent<Building>();
    }
    public override void HealthUnderZero()
    {
        cb.gameObject.SetActive(true);
        ResetToMaxHealth();
        building.ResetLevel();
        OnBuildingHealthUnderZero?.Invoke();
        gameObject.SetActive(false);
    }

    public override void OnHit()
    {
        transform.DOShakeScale(0.3f,2f,2,10,true,ShakeRandomnessMode.Harmonic).OnKill(() => transform.localScale = originalLocalScale);

    }
}
