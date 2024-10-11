using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile prefab
    public Transform spawnPoint; // The point where projectiles are spawned
    public float spawnInterval = 2f; // Time between projectile spawns
    private bool canSpawn = false; // Flag to control spawning

    void Update()
    {
        if (canSpawn)
        {
            SpawnProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canSpawn = true; // Enable spawning when player enters the trigger
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canSpawn = false; // Disable spawning when player exits the trigger
        }
    }

    private void SpawnProjectile()
    {
        Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity); // Spawn the projectile
        canSpawn = false; // Disable spawning after one spawn
        Invoke(nameof(ResetSpawn), spawnInterval); // Reset spawning after the interval
    }

    private void ResetSpawn()
    {
        canSpawn = true; // Re-enable spawning
    }
}
