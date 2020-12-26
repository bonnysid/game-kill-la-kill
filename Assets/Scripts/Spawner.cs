using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] mobs;
    public float spawnDelay = 10f;
    public int plusEnemyPerWave = 2;
    public int startAmountOfMobs = 2;
    private bool isAllEnemyDead = true;
    private int amountOfMobs;
    private float delay;
    public Transform[] spawnPoints;    
    void Start() {
        amountOfMobs = startAmountOfMobs;
        delay = spawnDelay;
    }

    // Update is called once per frame
    void Update() {
        isAllEnemyDead = GameObject.FindGameObjectsWithTag("Enemy").Length == 0 ? true : false;
        if (isAllEnemyDead) {
           if(delay <= 0) {
                for(int i = 0; i < amountOfMobs; i++) {
                    GameObject mob = mobs[Random.Range(0, mobs.Length)];
                    Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                    Instantiate(mob, spawnPoint.position, spawnPoint.rotation);
				}
                amountOfMobs += plusEnemyPerWave;
            delay = spawnDelay;
			} else {
                delay -= Time.deltaTime;
            }
        } 
    }
}
