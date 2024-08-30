using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : Attacking
{
    [HideIf("isSword")]
    [SerializeField] private bool isArcher;
    [HideIf("isArcher")]
    [SerializeField] private bool isSword;

    public override void Attack()
    {
        if(isArcher)
        {
            // fire projectile
        }

        if(isSword)
        {
            // other logic maybe
        }


        GetHealthColliderObject().GetDamage(damage);
        // play attack animation
    }

    public override void Move()
    {
        // walk animation
    }
}
