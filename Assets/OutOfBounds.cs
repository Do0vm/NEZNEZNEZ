using UnityEngine;

public class OutOfBounds : MonoBehaviour
{

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Die();
        }
    }
}
