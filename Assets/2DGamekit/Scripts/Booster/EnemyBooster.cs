using UnityEngine;

public class EnemyBooster : MonoBehaviour
{
    // Variables to control the boost force
    public float boostForce = 10f;

    // This function is called when another object with a collider enters this object's collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object that collided with the booster is the player
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Get the Rigidbody2D component of the player
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                // Apply an upward force to the player
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0); // Reset the vertical velocity
                playerRigidbody.AddForce(Vector2.up * boostForce, ForceMode2D.Impulse);
            }
        }
    }
}
