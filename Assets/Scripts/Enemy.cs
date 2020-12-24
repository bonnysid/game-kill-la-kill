using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float speed = 10;
    private float direction = -1f;
    private Rigidbody2D rigidbody2D;
    public GameObject target;
    private bool isFacingRight = false;
    public int shootDistance = 5;
    private GunController gun;
    private Animator anim;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Character");
        direction = target.transform.localScale.x * -1;
        anim = GetComponent<Animator>();

    }
    void Update()
    {
        
        if (!IsCloseToTarget()) {
            rigidbody2D.velocity = new Vector2(speed * direction, rigidbody2D.velocity.y);
            anim.SetFloat("Speed", 1f);
        } else {
            anim.SetFloat("Speed", 0f);
        }
        
        if (target.transform.position.x > transform.position.x && !isFacingRight) Flip();
        else if (target.transform.position.x < transform.position.x && isFacingRight) Flip();

        if (health <= 0) {
            Destroy(gameObject);
		}


    }


    public void TakeDamage(int damage) {
        health -= damage;
	}

    private void Flip() {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        direction = theScale.x;
    }

    public bool IsCloseToTarget() {
        return Mathf.Abs(target.transform.position.x - transform.position.x) <= 5;
    }
}
