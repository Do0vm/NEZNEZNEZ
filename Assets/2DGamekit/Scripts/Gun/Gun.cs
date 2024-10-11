using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    public GameObject grenadePrefab;  // Drag your grenade prefab here
    public Transform grenadeSpawnPoint; // Assign the spawn point (front of character)
    public float grenadeSpeed = 10f; // Set the grenade speed
    public float grenadeUpwardForce = 5f; // Set how much upward force the grenade will have
    public float fireRate = 1f; // Time between grenade shots
    private float nextFireTime = 0f;

    public SpriteRenderer characterSpriteRenderer; // Reference to character's SpriteRenderer

    void Start()
    {
        // Automatically find the character's SpriteRenderer if not manually assigned
        if (characterSpriteRenderer == null)
        {
            characterSpriteRenderer = GetComponentInParent<SpriteRenderer>();
        }

        // If it's still null, print error
        if (characterSpriteRenderer == null)
        {
            Debug.LogError("Character's SpriteRenderer is not assigned and cannot be found!");
        }
    }

    void Update()
    {
        // Flip the gun based on character's flipX
        FlipGun();

        // Fire when left mouse button is pressed
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            LaunchGrenade();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void FlipGun()
    {
        // Check if character is flipped using flipX and adjust the gun's direction
        if (characterSpriteRenderer != null && characterSpriteRenderer.flipX)
        {
            // Flip the grenade spawn point to the left when character is facing left
            grenadeSpawnPoint.localPosition = new Vector3(-Mathf.Abs(grenadeSpawnPoint.localPosition.x), grenadeSpawnPoint.localPosition.y, grenadeSpawnPoint.localPosition.z);
        }
        else
        {
            // Set the spawn point to the right when the character is facing right
            grenadeSpawnPoint.localPosition = new Vector3(Mathf.Abs(grenadeSpawnPoint.localPosition.x), grenadeSpawnPoint.localPosition.y, grenadeSpawnPoint.localPosition.z);
        }
    }

    void LaunchGrenade()
    {
        // Instantiate grenade at spawn point
        GameObject grenade = Instantiate(grenadePrefab, grenadeSpawnPoint.position, grenadeSpawnPoint.rotation);

        // Adjust grenade scale directly after instantiation
        grenade.transform.localScale = new Vector3(0.5f, 0.5f, 1); // Adjust the scale as needed

        // Get the Rigidbody2D component of the grenade
        Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();

        // Calculate force based on the character's facing direction
        Vector2 launchDirection = characterSpriteRenderer != null && characterSpriteRenderer.flipX ? Vector2.left : Vector2.right;

        // Add force to the grenade (forward and upward for arc effect)
        rb.AddForce(launchDirection * grenadeSpeed + Vector2.up * grenadeUpwardForce, ForceMode2D.Impulse);
    }
}
