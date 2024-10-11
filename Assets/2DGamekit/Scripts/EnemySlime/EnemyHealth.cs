using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3; // Set the maximum health of the enemy
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Initialize the enemy's health
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Destroy the enemy when health reaches 0
        Destroy(gameObject);
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grenade"))
        {
            // Apply damage when the enemy is hit by a grenade
            TakeDamage(1); // You can change the damage amount as needed

            // Optionally destroy the grenade on impact
            Destroy(collision.gameObject);
        }
    }
}
