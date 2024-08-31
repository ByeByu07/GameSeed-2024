using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : Attacking
{
    [SerializeField] private float distanceToUseSword;

    public override void Attack()
    {
        //if (Vector3.Distance(transform.position, GetFirstColliderObject().transform.position) > distanceToUseSword)
        //{
        //    // fire arrow animation

        //    //fire arrow fire projectile

        //}
        //else
        //{
        //    // slash with sword animation
        //    //animator.CrossFade();
        //}
        GetHealthColliderObject().GetDamage(damage);
    }

    public override void Move()
    {
        //

    }
}
