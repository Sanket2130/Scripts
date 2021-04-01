using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2d : MonoBehaviour
{
    private Player_Base playerBase;
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        playerBase = gameObject.GetComponent<Player_Base>();
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpvelocity = 100f;
            rigidbody2D.velocity = Vector2.up * jumpvelocity;
        }
        
    }

    private void FixedUpdate()
    {
        float moveSpeed = 40f;
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.velocity = new Vector2(-moveSpeed , rigidbody2D.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
               rigidbody2D.velocity = new Vector2(+moveSpeed , rigidbody2D.velocity.y); 
            }
            else
            {
                //no keys pressed
                rigidbody2D.velocity = new Vector2(0 , rigidbody2D.velocity.y);
                rigidbody2D.constraints =
                    RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
