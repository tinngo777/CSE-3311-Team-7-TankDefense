using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private int MAX_HEALTH = 3; // Max health is now 3 hits
    [SerializeField] private int health = 3; // Player starts with 3 health
    [SerializeField] private Image healthBar; // Reference to the health bar UI
    [SerializeField] private GameObject gameOverScreen; // Reference to game over screen

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Negative Damage Taken!");
        }

        this.health -= amount;
        UpdateHealthBar(); // Update health bar UI

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Negative Healing!");
        }

        if (health + amount > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }

        UpdateHealthBar(); // Update health bar UI
    }

    private void UpdateHealthBar()
    {
        // Update the health bar based on the player's health (dividing by max health for percentage)
        healthBar.fillAmount = (float)health / MAX_HEALTH;
    }

    private void Die()
    {
        Debug.Log(this.name + " is Dead");
        gameOverScreen.SetActive(true); // Show game over screen
        Time.timeScale = 0; // Stop the game
    }

    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
        UpdateHealthBar();
    }
}
