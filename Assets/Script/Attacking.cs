using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class Attacking : MonoBehaviour, IColliderAttack
{
    [SerializeField] protected int damage;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float radius;
    [SerializeField] protected LayerMask layerToAttack;
    [SerializeField] protected float distanceToAttack;
    [SerializeField] protected float distanceToFollow;
    protected float attackSpeedCooldown;
    protected Collider hitCollider;
    protected Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        attackSpeedCooldown = attackSpeed;
    }

    void Update()
    {
        if(hitCollider == null )
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, layerToAttack);

            if (hitColliders.Length > 0)
            {
                hitCollider = hitColliders[0];
            }
            else
            {
                hitCollider = null;

                BackToPosition();
            }
        }
        else if (!GetFirstColliderObject().transform.gameObject.active)
        {
            hitCollider = null;
        }
        else
        {
           
            Behavior();
        }

    }

    public virtual void BackToPosition()
    {
        //throw new NotImplementedException();
    }

    public virtual void Behavior()
    {
        if (IsCanAttacking())
        {
            Attack();
        }
        else
        {
            Move();
        }
    }

    public virtual bool IsCanAttacking()
    {
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


    public virtual void Attack()
    {
        throw new NotImplementedException();
    }

    public virtual void Move()
    {
        throw new NotImplementedException();
    }

    public Collider GetFirstColliderObject()
    {
        return hitCollider;
    }

    public Health GetHealthColliderObject()
    {
        if(GetFirstColliderObject().TryGetComponent<Health>(out Health health))
        {
            return health;
        }

        return null;
    }

    private void OnDrawGizmosSelected()
    {
        // Draw the overlap sphere in the scene view when the object is selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
