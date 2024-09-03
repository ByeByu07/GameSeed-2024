using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopAttacking : Attacking
{
    Troop troop;
    private void Start()
    {
        troop = GetComponent<Troop>();
    }
    public override void Attack()
    {
        GetHealthColliderObject().GetDamage(damage);
    }

    public override void Move()
    {
        if (Vector3.Distance(transform.position, GetFirstColliderObject().gameObject.transform.position) < distanceToFollow)
        {
            troop.SetDestination(GetFirstColliderObject().gameObject.transform);
        }
        else
        {
            hitCollider = null;
        }
    }
}
