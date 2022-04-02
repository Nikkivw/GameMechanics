using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;

    [SerializeField] protected bool isDead;

    private void Start()
    {
        InitVariables();
    }

    public virtual void CheckHealth()
    {
        if(health <= 0)
        {
            health = 0;
            Death();
        }
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public void Death()
    {
        isDead = true;
    }

    private void SetHealtTo(int healtToSetTo)
    {
        health = healtToSetTo;
        CheckHealth();
    }

    public void TakeDamage(int Damage)
    {
        int HealthAftherDamage = health - Damage;
        SetHealtTo(HealthAftherDamage);
    }

    public void Heal(int Heal)
    {
        int healtAftherHeal = health + Heal;
        SetHealtTo(healtAftherHeal);
    }

    public void InitVariables()
    {
        maxHealth = 100;
        SetHealtTo(maxHealth);
        isDead = false;
    }
}
