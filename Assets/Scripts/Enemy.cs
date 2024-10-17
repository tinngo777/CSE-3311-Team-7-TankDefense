using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private float speed = 1.5f;
    [SerializeField]
    private EnemyData data;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
        Swarm();   
    }

    // Set enemy values
    void SetEnemyValues()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    // Method to constantly move enemy towards player
    private void Swarm()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // If collide with player
        if(collider.CompareTag("Player"))
        {
            if(collider.GetComponent<Health>() != null)
            {
                // On collision deal damage to player
                collider.GetComponent<Health>().Damage(damage);
                
                // Destroy the enemy after collision
                Debug.Log("Enemy destroyed after hitting the player");
                Destroy(gameObject);  // Immediately destroy the enemy
            }
        }

        // If hit by bullet
        if(collider.CompareTag("Bullet"))
        {
            // Destroy the enemy and the bullet
            Debug.Log("Enemy destroyed by bullet");
            Destroy(gameObject);   // Destroys the enemy
            Destroy(collider.gameObject);   // Destroys the bullet
        }
    }


}
