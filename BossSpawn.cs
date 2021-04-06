using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{

    public GameObject boss;
    public float spawnTime = 15f;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 30, spawnTime);
    }

    void Spawn()
    {
        if (PlayerController.dead == true)
        {
            BossSearch.bossSpeedFollow = 0;
            return;
        }
        else
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(boss, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}
