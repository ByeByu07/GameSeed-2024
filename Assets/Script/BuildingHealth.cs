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
        OnBuildingHealthUnderZero?.Invoke();
    }

    public override void OnHit()
    {
        transform.DOShakeScale(0.3f,2f,2,10,true,ShakeRandomnessMode.Harmonic).OnKill(() => transform.localScale = originalLocalScale);

    }
}
