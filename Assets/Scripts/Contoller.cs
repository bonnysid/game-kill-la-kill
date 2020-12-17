using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contoller : MonoBehaviour
{
    //Передвижение
    public float horizontalSpeed;
    public float verticalImpulse;
    float speedX;
    Rigidbody2D rb;
        // Прыжки
    bool isGrounded;
        // Развороты
    bool isTurned = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            speedX = -horizontalSpeed;
            if(isTurned == false)
            {
                Turning();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speedX = horizontalSpeed;
            if (isTurned == true)
            {
                Turning();
            }
        }
        transform.Translate(speedX, 0, 0);
        speedX = 0;
    }   

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
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

    private void Turning()
    {
        isTurned = !isTurned;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
