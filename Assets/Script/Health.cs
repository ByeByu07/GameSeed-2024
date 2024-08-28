using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int CurrentHealth { get; private set; }
    public int MaxHealth { get; private set; }
    [SerializeField] private Transform deadEffect;
    public void GetDamage(int damageTaken)
    {
        OnHit();
        if(CurrentHealth < damageTaken)
        {
            HealthUnderZero();
        }

        CurrentHealth -= damageTaken;
    }

    public void GetHeal(int healAmount)
    {
        if (CurrentHealth + healAmount > MaxHealth) 
        {
            CurrentHealth = MaxHealth;
        };

        if(CurrentHealth < MaxHealth)
        {
            CurrentHealth += healAmount;
        }
    }

    public void ResetToMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }

    public void SetMaxHealth(int healthAmount)
    {
        MaxHealth = healthAmount;
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
