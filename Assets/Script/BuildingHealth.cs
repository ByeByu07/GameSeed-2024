using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameInput;

public class BuildingHealth : Health
{
    public event Action OnBuildingHealthUnderZero;
    public override void HealthUnderZero()
    {
        gameObject.SetActive(false);
    }

    public override void OnHit()
    {
        transform.DOComplete();
        transform.DOShakeScale(0.3f, 0.5f, 5, 180, true).OnKill(() => transform.localScale = originalLocalScale);
    }
}
