using BTAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;


public class PlayerController : MonoBehaviour
{
    public float speed = 9f;
    public float jumpForce = 6f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool WhileJumping = false;
        GetComponent<Animator>().SetBool("HasGun", false);
        if (GetComponent<Animator>().GetBool("HasGun") != true )
      {
        GetComponent<Animator>().SetBool("Crouch", false);
        GetComponent<Animator>().SetBool("Jump", false);
        GetComponent<Animator>().SetBool("Damage", false);
      

            if (Input.GetKey(KeyCode.D))
        {

            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("Walking", true);
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }




        else if (Input.GetKey(KeyCode.Q))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("Walking", true);
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
            else
            {
                GetComponent<Animator>().SetBool("Walking", false);
            }

        if (Input.GetKeyDown(KeyCode.Space))
        {
                GetComponent<Animator>().SetTrigger("Jump");
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpForce);



        }
        if (Input.GetKeyDown(KeyCode.C))
            {
                GetComponent<Animator>().SetTrigger("Crouch");

            }


        }


        else
        {
           


        }

    }


    
}
