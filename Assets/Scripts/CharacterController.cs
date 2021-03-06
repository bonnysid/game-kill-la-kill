﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public int health = 100;
    public float maxSpeed = 10f;
    private bool isFacingRight = true;
    private bool isGrounded = false;
    private float groundRadius = 0.2f;
    public int healthPerSec = 5;

    private Animator anim;
    private Rigidbody2D rigidbody2D;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    private void Start() {
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {

        if (health <= 0)
        {
            SceneLoader sceneLoader = new SceneLoader();
            sceneLoader.GameOver();
            Destroy(gameObject);
        }
        if (health < 100 && Time.frameCount % 1000 == 0) health += healthPerSec;

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

        if (move > 0 && !isFacingRight) Flip();
        else if (move < 0 && isFacingRight) Flip();
       
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", isGrounded);
        anim.SetFloat("vSpeed", rigidbody2D.velocity.y);

        if (!isGrounded) return;
    }

    private void Update() {
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))) {
            anim.SetBool("Ground", false);
            rigidbody2D.AddForce(new Vector2(0, 600));
        }
    }


    private void Flip() {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void TakeDamage(int damage) {
        health -= damage;
    }
}
