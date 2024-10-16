using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    public float speed;

    private Rigidbody2D rb;
    private Animator anim;
    private Transform CurrentPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        CurrentPoint = PointB.transform;
        anim.SetBool("IsWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = CurrentPoint.position - transform.position;
        if (CurrentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }

        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == PointB.transform)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            CurrentPoint = PointA.transform;
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == PointA.transform)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            CurrentPoint = PointB.transform;
        }



    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);
        
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }
}
         

  