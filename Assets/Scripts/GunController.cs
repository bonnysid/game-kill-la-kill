using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
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
    

    private void Start() {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (timeBtwShots <= 0) {
            if (Input.GetMouseButton(0) && !PauseMenu.gameIsPaused) {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            } 
        } else {
            timeBtwShots -= Time.deltaTime;
		}

    }

}
