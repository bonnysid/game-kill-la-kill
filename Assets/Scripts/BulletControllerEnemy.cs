using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerEnemy : MonoBehaviour
{
    public float speed = 30;
    public float lifeTime = 10;
    public float distance = 0.5f;
    public int damage = 15;
    public LayerMask whatIsSolid;
    private Rigidbody2D rigidbody2D;
    private float direction;
    public GameObject parent;
    private void Start() {
        Destroy(gameObject, lifeTime);
        rigidbody2D = GetComponent<Rigidbody2D>();
        direction = parent.transform.localScale.x;
        Vector3 dirSprite = transform.localScale;
        dirSprite.x *= direction;
        transform.localScale = dirSprite;
    }
    // Update is called once per frame
    void Update() {
        rigidbody2D.velocity = new Vector2(direction * speed, rigidbody2D.velocity.y);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null) {
            if (hitInfo.collider.CompareTag("Player")) {
                hitInfo.collider.GetComponent<CharacterController>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        //transform.Translate(new Vector3(Transform.localScale.x * speed * Time.deltaTime, 0, 0));
    }
}
