using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public event EventHandler<OnHitEventHandler> OnHitEH;
    public class OnHitEventHandler { public float restHealth; }

    [SerializeField] protected int currentHealth;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected Transform deadEffect;
    protected Vector3 originalLocalScale;

    private void Start()
    {
        currentHealth = maxHealth;
        originalLocalScale = transform.localScale;
    }

    public void GetDamage(int damageTaken)
    {
        OnHit();
        if(currentHealth < damageTaken)
        {
            HealthUnderZero();
        }

        currentHealth -= damageTaken;
    }

    public void GetHeal(int healAmount)
    {
        if (currentHealth + healAmount > maxHealth) 
        {
            currentHealth = maxHealth;
        };

        if(currentHealth < maxHealth)
        {
            currentHealth += healAmount;
        }
    }

    public void ResetToMaxHealth()
    {
        currentHealth = maxHealth;
    }

    public void SetMaxHealth(int healthAmount)
    {
        maxHealth = healthAmount;
    }

    public virtual void HealthUnderZero()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnHit()
    {
        OnHitEH?.Invoke(this, new OnHitEventHandler { restHealth = (float) currentHealth / maxHealth });
        transform.DOComplete();
        transform.DOShakeScale(0.3f, 0.5f, 5, 180, true).OnKill(() => { if (transform) { transform.localScale = originalLocalScale; } });
    }
}
