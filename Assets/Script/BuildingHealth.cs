using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : Health
{
    public override void HealthUnderZero()
    {
        Destroy(gameObject);
    }

    public override void OnHit()
    {
        base.OnHit();
    }
}
