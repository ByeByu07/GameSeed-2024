using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopAttacking : Attacking
{
    Troop troop;
    [SerializeField] private TowerBullet bulletPrefab;

    [HideIf("isArcher")]
    [SerializeField] private bool isSword;

    [HideIf("isSword")]
    [SerializeField] private bool isArcher;

    private void Start()
    {
        troop = GetComponent<Troop>();
    }
    public override void Attack()
    {
        if(isSword)
        {

        }

        if(isArcher)
        {
            TowerBullet bulletClone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletClone.Attack(GetFirstColliderObject(), damage);
        }

        GetHealthColliderObject().GetDamage(damage);
    }

    public override void Move()
    {
        if (Vector3.Distance(transform.position, GetFirstColliderObject().gameObject.transform.position) < distanceToFollow)
        {
            if(isArcher)
            {
                if (Vector3.Distance(transform.position, GetFirstColliderObject().gameObject.transform.position) < distanceToAttack)
                {
                    troop.SetDestination(transform);
                }
            } else
            {
                troop.SetDestination(GetFirstColliderObject().gameObject.transform);
            }
            
        }
        else
        {
            hitCollider = null;
        }
    }
}
