using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopHealth : Health
{
    private Troop troop;
    private void Start()
    {
        troop = GetComponent<Troop>();
        currentHealth = maxHealth;
        originalLocalScale = transform.localScale;
    }

    public override void HealthUnderZero()
    {
        //gameObject.SetActive(false);
        //ResetToMaxHealth();

        Destroy(gameObject);
    }

    public override void OnHit()
    {
        base.OnHit();
    }
}
