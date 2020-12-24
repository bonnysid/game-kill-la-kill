using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemyController : MonoBehaviour
{
    //public int damage;
    public GameObject bullet;
    public float startTimeBtwShots;
    public Transform shotPoint;

    private bool isShooting = false;
    private Animator anim;
    private Transform playerTransform;
    private bool isFacingRight = true;
    private float timeBtwShots;
    private Enemy parent;


    private void Start() {
        anim = GetComponent<Animator>();
        parent = gameObject.GetComponentInParent<Enemy>();
    }

    void Update() {

        if (timeBtwShots <= 0) {
            if (parent.IsCloseToTarget()) {
                isShooting = true;
                Instantiate(bullet, shotPoint.position, parent.transform.rotation);
                timeBtwShots = startTimeBtwShots;
            } else {
                isShooting = false;
            }
        } else {
            timeBtwShots -= Time.deltaTime;
        }

        anim.SetBool("isShooting", isShooting);
    }
}
