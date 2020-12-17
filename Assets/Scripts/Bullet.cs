using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 7f;
    public float disappearTime = 5;
    public float damage = 1;
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        //        transform.position = new Vector3(transform.position.x, transform.position.y, -1f);

        disappearTime = disappearTime - Time.deltaTime;
        if (disappearTime <= 0) Destroy(gameObject);
    }

    /*private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
    */


}
