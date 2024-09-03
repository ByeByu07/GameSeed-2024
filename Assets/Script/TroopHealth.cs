using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopHealth : Health
{
    private Troop troop;
    private void Start()
    {
        troop = GetComponent<Troop>();
    }

    public override void HealthUnderZero()
    {
        gameObject.SetActive(false);
        ResetToMaxHealth();
    }

    public override void OnHit()
    {
        base.OnHit();
    }
}
