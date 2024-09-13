using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : Attacking
{
    [SerializeField] private float distanceToUseSword;
    [SerializeField] private TowerBullet bulletPrefab;

    private readonly int ATTACK_SWORD = Animator.StringToHash("PlayerWithSwordAttack");
    private readonly int ATTACK_ARCHER = Animator.StringToHash("PlayerWithArcherAttack");

    public override void Attack()
    {
        if (Vector3.Distance(transform.position, GetFirstColliderObject().transform.position) > distanceToUseSword)
        {
            // fire arrow animation

            //fire arrow fire projectile
            animator.SetTrigger("Archer");
            TowerBullet bulletClone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletClone.Attack(GetFirstColliderObject(), damage);
        }
        else
        {
            // slash with sword animation
            animator.SetTrigger("Sword");
            GetHealthColliderObject().GetDamage(damage);
        }
    }

    public override void Move()
    {
        hitCollider = null;
    }
}
