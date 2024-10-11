using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; 
    private int currentHealth;

    public Image[] hearts; 
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        currentHealth = maxHealth; 
        UpdateHearts(); 
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die(); 
        }

        UpdateHearts(); 
    }

    void UpdateHearts()
    {
        
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart; // Show full heart
            }
            else
            {
                hearts[i].sprite = emptyHeart; // Show empty heart
            }
        }
    }

    public static void Die()
    {
        SceneManager.LoadScene("Death");
        Debug.Log("Player is dead");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            TakeDamage(1); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1); 
        }
    }
}
