using System.Collections;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile prefab to spawn
    public GameObject boss; // Reference to the boss GameObject
    public float spawnInterval = 2f; // Time between spawns
    private bool canSpawn = false; // Indicates if spawning is active

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if the player enters the trigger
        {
            canSpawn = true; // Enable spawning
            StartCoroutine(SpawnProjectiles()); // Start spawning projectiles
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if the player exits the trigger
        {
            canSpawn = false; // Disable spawning
        }
    }

    private IEnumerator SpawnProjectiles()
    {
        while (canSpawn)
        {
            // Spawn the projectile at the boss's position
            Instantiate(projectilePrefab, boss.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval); // Wait for the specified interval
        }
    }
}
