using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f;  // Bullet lasts 3 seconds
    [SerializeField] private int bulletDamage = 10; // Adjust bullet damage as needed

    void Start()
    {
        // Destroy the bullet after its lifetime ends
        Destroy(gameObject, lifetime);
    }
/*
    void OnTriggerEnter2D(Collider2D other)
    {
        // Handle collision with enemies
        if (other.CompareTag("Enemy"))
        {
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
            {
                // Damage the enemy
                enemyHealth.Damage(bulletDamage);
            }

            // Destroy the bullet after hitting the enemy
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Player")) // Prevent bullet from destroying when it hits the player
        {
            Destroy(gameObject); // Destroy on hitting other objects
        }
    }
    */
}
