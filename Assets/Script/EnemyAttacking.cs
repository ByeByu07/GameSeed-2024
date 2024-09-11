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
    [SerializeField] LayerMask playerLayer;
    public override void Behavior()
    {
        if (IsCanAttacking())
        {
            Attack();
        } else {
            Move();
        }
    }

    public override void BackToPosition()
    {
        enemy.SetDestionationToSeed();
    }

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
        if (Vector3.Distance(transform.position, GetFirstColliderObject().gameObject.transform.position) < distanceToFollow)
        {
            enemy.SetDestination(GetFirstColliderObject().gameObject.transform);
        } else
        {
            hitCollider = null;
        }
    }

    public override bool IsCanAttacking()
    {
        //if(!GetFirstColliderObject().GetComponent<Building>().IsActive()) return false;

        if (Vector3.Distance(transform.position, GetFirstColliderObject().gameObject.transform.position) < distanceToAttack)
        {
            attackSpeedCooldown -= Time.deltaTime;
            if (attackSpeedCooldown < 0)
            {
                attackSpeedCooldown = attackSpeed;
                return true;
            }
        }
        return false;
    }
}

