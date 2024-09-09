using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override void HealthUnderZero()
    {
        Destroy(gameObject);
        Instantiate(GameAssets.Instance?.EnemyDead, transform.position, Quaternion.identity);
    }
    public override void OnHit()
    {
        base.OnHit();
    }
}
