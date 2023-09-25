using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public event EventHandler<float> OnHealthChanged;

    [SerializeField]
    protected float health;
    [SerializeField]
    protected float maxHealth;

    [SerializeField]
    protected bool isDead;

    private void Awake()
    {
        Init();
    }
    public void CheckHelth()
    {
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        if (health >= maxHealth)
        {
            health = maxHealth;
        }

        OnHealthChanged?.Invoke(this, health);
    }

    public virtual void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }

    protected void SetHealth(float healthToSet)
    {
        health = healthToSet;
        CheckHelth();
    }

    public void TakeDamage(float damage)
    {
        float healthAfterDamage = health - damage;
        SetHealth(healthAfterDamage);
    }

    public void Heal(int heal)
    {
        float healthAfterHeal = health + heal;
        SetHealth(healthAfterHeal);
    }

    public virtual void Init()
    {
        maxHealth = 100;
        SetHealth(maxHealth);
        isDead = false;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
