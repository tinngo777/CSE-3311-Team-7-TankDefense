using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField]
    private int health = 100;
    
    private int MAX_HEALTH = 100;

    // Event to notify health change
    public event Action<int, int> OnHealthChanged;

    // Access for HealthBar.cs
    public int CurrentHealth => health;
    public int MaxHealth => MAX_HEALTH;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
    }

    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
        OnHealthChanged?.Invoke(health, MAX_HEALTH);
    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Negative Damage");
        }

        health -= amount;
        
        // lock health at 0
        health = Mathf.Max(health, 0);
        
        StartCoroutine(VisualIndicator(Color.red));
        OnHealthChanged?.Invoke(health, MAX_HEALTH); // Notify listener

        if(health <= 0)
        {   
            Die();
        }
    }

    public void Heal(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Negative Healing");
        }
        
        bool overMaxHealth = health + amount > MAX_HEALTH;
        StartCoroutine(VisualIndicator(Color.green));

        if(overMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }

    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
