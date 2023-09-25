using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStats : CharacterStats
{
    [SerializeField]
    private int damage;
    [SerializeField]
    public float atackSpeed;

    [SerializeField]
    private bool canAtack;

    private void Awake()
    {
        Init();        
    }

    public void DealDamage(CharacterStats statsToDamage)
    {
        statsToDamage.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }

    public override void Init()
    {
        maxHealth = 25;
        SetHealth(maxHealth);

        damage = 10;
        atackSpeed = 1.5f;
        canAtack = true;
    }
}
