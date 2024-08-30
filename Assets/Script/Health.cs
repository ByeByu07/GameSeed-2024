using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int CurrentHealth { get; private set; }
    [SerializeField] private int maxHealth;
    [SerializeField] private Transform deadEffect;

    private void Start()
    {
        CurrentHealth = maxHealth;
    }

    public void GetDamage(int damageTaken)
    {
        //OnHit();
        if(CurrentHealth < damageTaken)
        {
            HealthUnderZero();
        }

        CurrentHealth -= damageTaken;
    }

    public void GetHeal(int healAmount)
    {
        if (CurrentHealth + healAmount > maxHealth) 
        {
            CurrentHealth = maxHealth;
        };

        if(CurrentHealth < maxHealth)
        {
            CurrentHealth += healAmount;
        }
    }

    public void ResetToMaxHealth()
    {
        CurrentHealth = maxHealth;
    }

    public void SetMaxHealth(int healthAmount)
    {
        maxHealth = healthAmount;
    }

    public virtual void HealthUnderZero()
    {
        throw new NotImplementedException();
    }

    public virtual void OnHit()
    {
        throw new NotImplementedException();
    }
}
