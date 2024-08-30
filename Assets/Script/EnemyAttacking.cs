using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : Attacking
{
    [HideIf("isShortRange")]
    [SerializeField] private bool isLongRange;
    [HideIf("isLongRange")]
    [SerializeField] private bool isShortRange;
    [SerializeField] private Enemy enemy;

    public override void Attack()
    {
        enemy.enabled = false;

        if(isLongRange)
        {
            // fire projectile
        }

        if(isShortRange)
        {
            // other logic maybe

        }


        GetHealthColliderObject().GetDamage(damage);
        // play attack animation
    }

    public override void Move()
    {
        enemy.enabled = true;
        // walk animation
    }
}
