using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Car")|| collision.gameObject.CompareTag("Lily"))
        {
            Destroy(collision.gameObject);
        }
        
        
    }
}
