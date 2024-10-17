using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f;

    void Start()
    {
        // Destroy the bullet after its lifetime ends
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Handle collision with enemies or other objects
        if (other.CompareTag("Enemy"))
        {
            // Damage the enemy
            other.GetComponent<Health>().Damage(10);  // assuming 10 damage, you can adjust this
            // Destroy the bullet after hitting the enemy
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Player")) // Prevent bullet from destroying when it hits the player
        {
            Destroy(gameObject); // Destroy on hitting other objects
        }
    }
}
