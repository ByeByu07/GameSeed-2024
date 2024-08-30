using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class Attacking : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected int radius;
    [SerializeField] protected LayerMask layerToAttack;
    float attackSpeedCooldown;
    Collider hitCollider;
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
            }
        }

        if (IsCanAttacking()) {
            Attack();
        } else
        {
            Move();
        }
    }

    public bool IsCanAttacking()
    {
        attackSpeedCooldown -= Time.deltaTime;
        if (attackSpeedCooldown < 0 & hitCollider != null)
        {
            return true;
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
