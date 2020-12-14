﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contoller : MonoBehaviour
{
    public float horizontalSpeed;
    float speedX;
    public float verticalImpulse;
    Rigidbody2D rb;
    bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            speedX = -horizontalSpeed;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            speedX = horizontalSpeed;
        }
        transform.Translate(speedX, 0, 0);
        speedX = 0;
    }   

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }


}
