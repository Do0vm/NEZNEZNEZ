using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int bossMaxHealth = 3; // Set the maximum health of the enemy
    private int bossCurrentHealth;

    void Start()
    {
        bossCurrentHealth = bossMaxHealth; // Initialize the enemy's health
    }

    public void bossTakeDamage(int damage)
    {
        bossCurrentHealth -= damage;

        if (bossCurrentHealth <= 0)
        {
            bossDie();
        }
    }

    void bossDie()
    {
        // Destroy the enemy when health reaches 0
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grenade"))
        {
            // Apply damage when the enemy is hit by a grenade
            bossTakeDamage(1); // You can change the damage amount as needed

            // Optionally destroy the grenade on impact
            Destroy(collision.gameObject);
        }
    }
}
