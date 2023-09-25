using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int maxHealth;

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
            isDead = true;
        }
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public virtual void Die()
    {
        isDead = true;
    }

    protected void SetHealth(int healthToSet)
    {
        health = healthToSet;
        CheckHelth();
    }

    public void TakeDamage(int damage)
    {
        int healthAfterDamage = health - damage;
        SetHealth(healthAfterDamage);
    }

    public void Heal(int heal)
    {
        int healthAfterHeal = health + heal;
        SetHealth(healthAfterHeal);
    }

    public virtual void Init()
    {
        maxHealth = 100;
        SetHealth(maxHealth);
        isDead = false;
    }
}
