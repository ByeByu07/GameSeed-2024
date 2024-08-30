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
    [SerializeField] private float distanceToFollow;

    public override void Attack()
    {
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
        enemy.SetDestionationToSeed();
        // walk animation
    }

    public override bool IsCanAttacking()
    {
        if(hitCollider != null)
        {
            enemy.SetDestination(GetFirstColliderObject().gameObject.transform);
            Debug.Log("collide");
            attackSpeedCooldown -= Time.deltaTime;
            if (attackSpeedCooldown < 0)
            {
                if (Vector3.Distance(transform.position, GetFirstColliderObject().gameObject.transform.position) < distanceToFollow)
                {
                    return true;
                }
            }
        }
        return false;
    }
}

